    class MyTest01 : BitField {
        [BitInfo(3)]
        public bool d0;
        [BitInfo(3)]
        public short d1;
        [BitInfo(3)]
        public int d2;
        [BitInfo(3)]
        public int d3;
        [BitInfo(3)]
        public int d4;
        [BitInfo(3)]
        public int d5;
        public MyTest01(bool _d0, short _d1, int _d2, int _d3, int _d4, int _d5) {
            d0 = _d0;
            d1 = _d1;
            d2 = _d2;
            d3 = _d3;
            d4 = _d4;
            d5 = _d5;
        }
        public MyTest01(byte[] datas) {
            parse(datas);
        }
        public new string ToString() {
            return string.Format("d0: {0}, d1: {1}, d2: {2}, d3: {3}, d4: {4}, d5: {5} \r\nbinary => {6}",
                d0, d1, d2, d3, d4, d5, ArrayConverter.toBinary(toArray()));
        }
    };
    class MyTest02 : BitField {
        [BitInfo(5)]
        public bool val0;
        [BitInfo(5)]
        public byte val1;
        [BitInfo(15)]
        public uint val2;
        [BitInfo(15)]
        public float val3;
        [BitInfo(15)]
        public int val4;
        [BitInfo(15)]
        public int val5;
        [BitInfo(15)]
        public int val6;
        public MyTest02(bool v0, byte v1, uint v2, float v3, int v4, int v5, int v6) {
            val0 = v0;
            val1 = v1;
            val2 = v2;
            val3 = v3;
            val4 = v4;
            val5 = v5;
            val6 = v6;
        }
        public MyTest02(byte[] datas) {
            parse(datas);
        }
        public new string ToString() {
            return string.Format("val0: {0}, val1: {1}, val2: {2}, val3: {3}, val4: {4}, val5: {5}, val6: {6}\r\nbinary => {7}",
                val0, val1, val2, val3, val4, val5, val6, ArrayConverter.toBinary(toArray()));
        }
    }
    public class MainClass {
        public static void Main(string[] args) {
            MyTest01 p = new MyTest01(false, 1, 2, 3, -1, -2);
            Debug.Log("P:: " + p.ToString());
            MyTest01 p2 = new MyTest01(p.toArray());
            Debug.Log("P2:: " + p2.ToString());
            MyTest02 t = new MyTest02(true, 1, 12, -1.3f, 4, -5, 100);
            Debug.Log("t:: " + t.ToString());
            MyTest02 t2 = new MyTest02(t.toArray());
            Debug.Log("t:: " + t.ToString());
            Console.Read();
            return;
        }
    }
