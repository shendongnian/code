        public static int CountLines(Stream stm)
        {
            StreamReader _reader = new StreamReader(stm);
            int c = 0, count = 0;
            while ((c = _reader.Read()) != -1)
            {
                if (c == '\n')
                {
                    count++;
                }
            }
            return count;
        }
