    [StructLayout(LayoutKind.Explicit)]
    public class lng_cnvt
    {
        private static Dictionary<string, FieldInfo[]> arrayMembers;
        static lng_cnvt()
        {
            arrayMembers = new Dictionary<string, FieldInfo[]>();
            arrayMembers.Add("cmd", typeof(lng_cnvt).GetFields(BindingFlags.NonPublic | BindingFlags.Instance).
                Where(x => x.Name.StartsWith("cmd")).OrderBy(y => y.Name).ToArray());
            arrayMembers.Add("data", typeof(lng_cnvt).GetFields(BindingFlags.NonPublic | BindingFlags.Instance).
                Where(x => x.Name.StartsWith("data")).OrderBy(y => y.Name).ToArray());
        }
        [FieldOffset(0)]
        private short cmd0;
        [FieldOffset(2)]
        private short cmd1;
        [FieldOffset(4)]
        private short cmd2;
        [FieldOffset(6)]
        private short cmd3;
        [FieldOffset(0)]
        private long data0;
        [FieldOffset(8)]
        private long data1;
        [FieldOffset(0)]
        public long data64;
        public dynamic this[int index, string name = "cmd"]
        {
            get
            {
                return arrayMembers[name][index].GetValue(this);
            }
            set
            {
                arrayMembers[name][index].SetValue(this, value);
            }
        }
    }
