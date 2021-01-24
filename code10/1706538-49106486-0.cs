            byte[] data = new byte[64];
            string a = Convert.ToString(data[20], 2);
            StringBuilder sb = new StringBuilder();
            foreach(char ch in a.ToCharArray())
            {
                sb.Append(ch+",");
            }
            // This is to remove last extra ,
            string ans = sb.ToString().Remove(sb.Length - 1, 1);
