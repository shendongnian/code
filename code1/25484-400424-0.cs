        using (StreamReader sr = new StreamReader(path)) 
        {
            //This is an arbitrary size for this example.
            char[] c = null;
            while (sr.Peek() >= 0) 
            {
                c = new char[5];
                sr.Read(c, 0, c.Length);
                //The output will look odd, because
                //only five characters are read at a time.
                Console.WriteLine(c);
            }
        }
