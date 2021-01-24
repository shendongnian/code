            byte[] data = new byte[64];
            // 2nd parameter 2 is Base e.g.(binary)
            string a = Convert.ToString(data[data.Length], 2);
            StringBuilder sb = new StringBuilder();
            foreach(char ch in a.ToCharArray())
            {
                sb.Append(ch+",");
            }
            // This is to remove last extra ,
            string ans = sb.ToString().Remove(sb.Length - 1, 1);
