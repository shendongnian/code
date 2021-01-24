        public static string RemoveDataPoints(this string data, string indentifier)
        {
            var temp = "";
            var fields = data.Split(";".ToCharArray(), StringSplitOptions.RemoveEmptyEntries);
            for (int i=0; i<fields.Length; i=i+2)
            {
                if (!fields[i].Equals(indentifier))
                {
                    temp += String.Format("{0};{1};", fields[i], fields[i + 1]);
                }
            }
            return temp;
        }
