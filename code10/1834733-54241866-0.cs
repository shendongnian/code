    string str = richTextBox1.Text;
            var array = str.Split(new[] { Environment.NewLine }, StringSplitOptions.RemoveEmptyEntries);
            var regex = new Regex(@"(?<Value>([+-]?(\d*\.)?\d+)+)", RegexOptions.Compiled);
            MatchCollection matches = regex.Matches(str);
            foreach (Match la in matches)
            {
                Console.writeLine(la);
            }
  
