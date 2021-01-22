    class Program
    {
        static void Main(string[] args)
        {
            StringReader first = new StringReader("hello ");
            StringReader second = new StringReader("world");
            StringReader third = new StringReader("!");
            //writes "hello world!"
            Console.WriteLine(first.Union(second).Union(third).ReadToEnd());
            Console.Read();
        }
    }
    public static class Extensions
    {
        public static TextReader Union(this TextReader first, TextReader second)
        {
            return new ChainedTextReader(first, second);
        }
        private class ChainedTextReader : TextReader
        {
            private TextReader first;
            private TextReader second;
            private bool readFirst = true;
            public ChainedTextReader(TextReader first, TextReader second)
            {
                this.first = first;
                this.second = second;
            }
            public override int Peek()
            {
                if (readFirst)
                {
                    return first.Peek();
                }
                else
                {
                    return second.Peek();
                }
            }
            public override int Read()
            {
                if (readFirst)
                {
                    int value = first.Read();
                    if (value == -1)
                    {
                        readFirst = false;
                    }
                    else
                    {
                        return value;
                    }
                }
                return second.Read();
            }
            public override void Close()
            {
                first.Close();
                second.Close();
            }
            protected override void Dispose(bool disposing)
            {
                base.Dispose(disposing);
                if (disposing)
                {
                    first.Dispose();
                    second.Dispose();
                }
            }
        }
    }
