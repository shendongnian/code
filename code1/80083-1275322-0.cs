        class BaseFoo
        {
            public void Write() { Console.WriteLine("Hello simple world"); }
        }
        class DerFoo : BaseFoo
        {
            public void Write() { Console.WriteLine("Hello complicated world"); }
        }
        public unsafe static void Main()
        {
            BaseFoo bs = new DerFoo();
            bs.Write();
            bs.GetType().GetMethod("Write").Invoke(bs, null);
        }
