    class StringSteamReader {
        private StreamReader sr;
        public StringSteamReader(StreamReader sr) {
            this.sr = sr;
            this.Separator = ' ';
        }
        private StringBuilder sb = new StringBuilder();
        public string ReadWord() {
            eol = false;
            sb.Clear();
            char c;
            while (!sr.EndOfStream) {
                c = (char)sr.Read();
                if (c == Separator) break;
                if (IsNewLine(c)) {
                    eol = true;
                    char nextch = (char)sr.Peek();
                    while (IsNewLine(nextch)) {
                        sr.Read(); // consume all newlines
                        nextch = (char)sr.Peek();
                    }
                    break;
                }
                sb.Append(c);
            }
            return sb.ToString();
        }
        private bool IsNewLine(char c) {
            return c == '\r' || c == '\n';
        }
        public int ReadInt() {
            return int.Parse(ReadWord());
        }
        public double ReadDouble() {
            return double.Parse(ReadWord());
        }
        public bool EOF {
            get { return sr.EndOfStream; }
        }
        public char Separator { get; set; }
        bool eol;
        public bool EOL {
            get { return eol || sr.EndOfStream; }
        }
        public T ReadObject<T>() where T : IParsable, new() {
            var obj = new T();
            obj.Parse(this);
            return obj;
        }
        public int[] ReadIntArray() {
            int size = ReadInt();
            var a = new int[size];
            for (int i = 0; i < size; i++) {
                a[i] = ReadInt();
            }
            return a;
        }
        public double[] ReadDoubleArray() {
            int size = ReadInt();
            var a = new double[size];
            for (int i = 0; i < size; i++) {
                a[i] = ReadDouble();
            }
            return a;
        }
        public T[] ReadObjectArray<T>() where T : IParsable, new() {
            int size = ReadInt();
            var a = new T[size];
            for (int i = 0; i < size; i++) {
                a[i] = ReadObject<T>();
            }
            return a;
        }
        internal void NextLine() {
            eol = false;
        }
    }
    interface IParsable {
        void Parse(StringSteamReader r);
    }
