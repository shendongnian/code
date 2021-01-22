            using (MemoryStream ms = new MemoryStream())
            using (TextWriter writer = new StreamWriter(ms))
            {
                writer.Write("HELLO");
                writer.Flush();
                byte[] bytes = ms.ToArray();
            }
