            StreamReader reader = new StreamReader(@"c:\test.txt",Encoding.ASCII);
            reader.BaseStream.Seek(0, SeekOrigin.End);
            int count = 0;
            while (count <= 10)
            {
                reader.BaseStream.Position--;
                int c=reader.Read();
                reader.BaseStream.Position--;
                if (c == '\n')
                {
                    ++count;    
                }
            }
            string str = reader.ReadToEnd();
            string[] arr = str.Split('\n');
            reader.Close();
