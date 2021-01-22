        static void Main() {
            using (TextReader reader = File.OpenText("foo.bar")) { // [HERE]
                Write(reader);
            }
        }
        static void Write(TextReader reader) {
            Console.Write(reader.ReadToEnd());
        }
        static void Write(StreamReader reader) {
            throw new NotImplementedException();
        }
