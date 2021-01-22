        public void Update(string data)
        {
            Console.Write(string.Format("\r{0}", "".PadLeft(Console.CursorLeft, ' ')));
            Console.Write(string.Format("\r{0}", data));
        }
