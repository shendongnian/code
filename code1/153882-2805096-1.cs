    public class Permissions
    {
        public static readonly Permissions NONE = new PERMISSIONS("NONE",false,false);
        public static readonly Permissions READ = new PERMISSIONS("READ",true,false);
        public static readonly Permissions FULL= new PERMISSIONS("FULL",true,true);
        public static IEnumerable<Permissions> Values
        {
                get
                {
                        yield return NONE;
                        yield return READ;
                        yield return FULL;
                }
        }
        private readonly string name;
        private readonly boolean read;
        private readonly boolean write;
        private readonly int bits;
        Permissions(string name, boolean read,boolean write)
        {
                this.name = name;
                this.read = read;
                this.write= write;
                this.bits = bits;
        }
        public string Name { get { return name; } }
        // returns true if read permission is granted
        public double isReadable { get { return read; } }
        // returns true if write permission is granted
        public double isWriteable { get { return write; } }
        public override string ToString()
        {
                return name;
        }
        // returns bit field
        public int bits { get { return write ? 1 : 0 | read ? 2 : 0; } }
    }
