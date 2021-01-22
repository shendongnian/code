    [global::System.AttributeUsage(AttributeTargets.Field, AllowMultiple = false)]
    public sealed class BitInfoAttribute : Attribute {
        byte length;
        public BitInfoAttribute(byte length) {
            this.length = length;
        }
        public byte Length { get { return length; } }
    }
    public abstract class BitField {
       
        public void parse<T>(T[] vals) {
            analysis().parse(this, ArrayConverter.convert<T, uint>(vals));
        }
        public byte[] toArray() {
            return ArrayConverter.convert<uint, byte>(analysis().toArray(this));
        }
        public T[] toArray<T>() {
            return ArrayConverter.convert<uint, T>(analysis().toArray(this));
        }
        static Dictionary<Type, BitTypeInfo> bitInfoMap = new Dictionary<Type, BitTypeInfo>();
        private BitTypeInfo analysis() {
            Type type = this.GetType();
            if (!bitInfoMap.ContainsKey(type)) {
                List<BitInfo> infos = new List<BitInfo>();
                byte dataIdx = 0, offset = 0;
                foreach (System.Reflection.FieldInfo f in type.GetFields()) {
                    object[] attrs = f.GetCustomAttributes(typeof(BitInfoAttribute), false);
                    if (attrs.Length == 1) {
                        byte bitLen = ((BitInfoAttribute)attrs[0]).Length;
                        if (offset + bitLen > 32) {
                            dataIdx++;
                            offset = 0;
                        }
                        infos.Add(new BitInfo(f, bitLen, dataIdx, offset));
                        offset += bitLen;
                    }
                }
                bitInfoMap.Add(type, new BitTypeInfo(dataIdx + 1, infos.ToArray()));
            }
            return bitInfoMap[type];
        }
    }
    class BitTypeInfo {
        public int dataLen { get; private set; }
        public BitInfo[] bitInfos { get; private set; }
        public BitTypeInfo(int _dataLen, BitInfo[] _bitInfos) {
            dataLen = _dataLen;
            bitInfos = _bitInfos;
        }
        public uint[] toArray<T>(T obj) {
            uint[] datas = new uint[dataLen];
            foreach (BitInfo bif in bitInfos) {
                bif.encode(obj, datas);
            }
            return datas;
        }
        public void parse<T>(T obj, uint[] vals) {
            foreach (BitInfo bif in bitInfos) {
                bif.decode(obj, vals);
            }
        }
    }
    class BitInfo {
        private System.Reflection.FieldInfo field;
        private uint mask;
        private byte idx, offset, shiftA, shiftB;
        private bool isUnsigned = false;
        public BitInfo(System.Reflection.FieldInfo _field, byte _bitLen, byte _idx, byte _offset) {
            field = _field;
            mask = (uint)(((1 << _bitLen) - 1) << _offset);
            idx = _idx;
            offset = _offset;
            shiftA = (byte)(32 - _offset - _bitLen);
            shiftB = (byte)(32 - _bitLen);
            if (_field.FieldType == typeof(bool)
                || _field.FieldType == typeof(byte)
                || _field.FieldType == typeof(char)
                || _field.FieldType == typeof(uint)
                || _field.FieldType == typeof(ulong)
                || _field.FieldType == typeof(ushort)) {
                isUnsigned = true;
            }
        }
        public void encode(Object obj, uint[] datas) {
            if (isUnsigned) {
                uint val = (uint)Convert.ChangeType(field.GetValue(obj), typeof(uint));
                datas[idx] |= ((uint)(val << offset) & mask);
            } else {
                int val = (int)Convert.ChangeType(field.GetValue(obj), typeof(int));
                datas[idx] |= ((uint)(val << offset) & mask);
            }
        }
        public void decode(Object obj, uint[] datas) {
            if (isUnsigned) {
                field.SetValue(obj, Convert.ChangeType((((uint)(datas[idx] & mask)) << shiftA) >> shiftB, field.FieldType));
            } else {
                field.SetValue(obj, Convert.ChangeType((((int)(datas[idx] & mask)) << shiftA) >> shiftB, field.FieldType));
            }
        }
    }
    public class ArrayConverter {
        public static T[] convert<T>(uint[] val) {
            return convert<uint, T>(val);
        }
        public static T1[] convert<T0, T1>(T0[] val) {
            T1[] rt = null;
            // type is same or length is same
            // refer to http://stackoverflow.com/questions/25759878/convert-byte-to-sbyte
            if (typeof(T0) == typeof(T1)) { 
                rt = (T1[])(Array)val;
            } else {
                int len = Buffer.ByteLength(val);
                int w = typeWidth<T1>();
                if (w == 1) { // bool
                    rt = new T1[len * 8];
                } else if (w == 8) {
                    rt = new T1[len];
                } else { // w > 8
                    int nn = w / 8;
                    int len2 = (len / nn) + ((len % nn) > 0 ? 1 : 0);
                    rt = new T1[len2];
                }
                Buffer.BlockCopy(val, 0, rt, 0, len);
            }
            return rt;
        }
        public static string toBinary<T>(T[] vals) {
            StringBuilder sb = new StringBuilder();
            int width = typeWidth<T>();
            int len = Buffer.ByteLength(vals);
            for (int i = len-1; i >=0; i--) {
                sb.Append(Convert.ToString(Buffer.GetByte(vals, i), 2).PadLeft(8, '0')).Append(" ");
            }
            return sb.ToString();
        }
        private static int typeWidth<T>() {
            int rt = 0;
            if (typeof(T) == typeof(bool)) { // x
                rt = 1;
            } else if (typeof(T) == typeof(byte)) { // x
                rt = 8;
            } else if (typeof(T) == typeof(sbyte)) {
                rt = 8;
            } else if (typeof(T) == typeof(ushort)) { // x
                rt = 16;
            } else if (typeof(T) == typeof(short)) {
                rt = 16;
            } else if (typeof(T) == typeof(char)) {
                rt = 16;
            } else if (typeof(T) == typeof(uint)) { // x
                rt = 32;
            } else if (typeof(T) == typeof(int)) {
                rt = 32;
            } else if (typeof(T) == typeof(float)) {
                rt = 32;
            } else if (typeof(T) == typeof(ulong)) { // x
                rt = 64;
            } else if (typeof(T) == typeof(long)) {
                rt = 64;
            } else if (typeof(T) == typeof(double)) {
                rt = 64;
            } else {
                throw new Exception("Unsupport type : " + typeof(T).Name);
            }
            return rt;
        }
    }
