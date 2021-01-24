            private void button3_Click(object sender, EventArgs e)
            {
                string str = "‘";
                var encoding = System.Text.Encoding.Default;
                var values = encoding.GetBytes(str);
                Decimal dec = values[0];
                var hex = ToHexString(dec);
                string result = hex.ToString();
            }
         
           public static string ToHexString(Decimal dec)
            {
                var sb = new StringBuilder();
                while (dec > 1)
                {
                    var r = dec % 16;
                    dec /= 16;
                    sb.Insert(0, ((int)r).ToString("X"));
                }
                return sb.ToString();
            }
