            StringBuilder sb=new StringBuilder();
            foreach (var v in dict)
            {
                sb.Append(v.Key+"=>>");
                foreach (var i in v.Value)
                {
                    sb.Append(i.Key + ", " + i.Value);
                }
                sb.Append(Environment.NewLine);
            }
            Console.WriteLine(sb);
