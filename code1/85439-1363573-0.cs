    private void button1_Click(object sender, EventArgs e)
            {
                Regex reg = new Regex(@"\[%(?<b1>.*)%\]");
                richTextBox1.Text= reg.Replace(textBox1.Text, new MatchEvaluator(f1));
            }
    
            static string f1(Match m)
            {
                StringBuilder sb = new StringBuilder();
                string[] a = Regex.Split(m.Groups["b1"].Value, "<%[^%>]*%>");
                MatchCollection col = Regex.Matches(m.Groups["b1"].Value, "<%[^%>]*%>");
                for (int i = 0; i < a.Length; i++)
                {
                    sb.Append(a[i].Replace("&", "&amp;").Replace("'", "&apos;").Replace("\"", "&quot;").Replace("<", "&lt;").Replace(">", "&gt;"));
                    if (i < col.Count)
                        sb.Append(col[i].Value);
                }
                return sb.ToString();
            }
