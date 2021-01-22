    string[] keys = message.Headers.AllKeys;
            Console.WriteLine("Headers");
            foreach (string s in keys)
            {
                Console.WriteLine("{0}:", s);
                Console.WriteLine("    {0}", message.Headers[s]);
