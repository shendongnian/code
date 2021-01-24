            var stringOrdered = textBox1.Lines.OrderByDescending(t => t.Length);
            var mostLargeStrings = stringOrdered.Where(str=> str.Length == stringOrdered.First().Length);             
            var index = 0;
            foreach(var TXT in mostLargeStrings)
            {
                index = Array.IndexOf(textBox1.Lines, TXT, index+1);
                MessageBox.Show(string.Format("MAX: {0} ",index));
            }
