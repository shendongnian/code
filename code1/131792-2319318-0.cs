    public class Comparer : IComparer<string>
        {
    
          private Dictionary<string, int> _order;
    
          public Comparer()
          {
            List<string> list = new List<string>()
            {
                "CS01",
                "CS10",
                "CS58",
                "CS11",
                "CS71",
                "CS02",
                "CS55",
                "CS03",
                "CS70",
                "CS54",
                "CS60",
                     //<---How to prioritize any value that is not predefined in list to show up here?  such as 1234-444-555
                "CS57",
    
            };
    
            _order = new Dictionary<string, int>();
            for (int i = 0; i < list.Count; i++)
            {
              _order.Add(list[i], i);
            }
          }
    
          public int Compare(string x, string y)
          {
            //If either string is less than 4 characters, return the comparsion of the two strings
            if (x.Length < 4 || y.Length < 4)
              return x.CompareTo(y);
    
            string xPrefix = x.Substring(0, 4);
            string yPrefix = y.Substring(0, 4);
    
            int xSequence;
            int ySequence;
            if (_order.TryGetValue(xPrefix, out xSequence)
                && _order.TryGetValue(yPrefix, out ySequence))
            {
              // If both X and Y are in dictionary, return the comparison of the two
              return xSequence.CompareTo(ySequence);
            }
            
            if (_order.TryGetValue(xPrefix, out xSequence))
            {
              // If only X is in dictionary, x > y
              return 1;
            }
    
            if (_order.TryGetValue(yPrefix, out ySequence))
            {
              // If only y is in dictionary, x < y 
              return -1;
            }
           
            // otherwise return the comparison of the two 
            return x.CompareTo(y);
            
          }
        }
    
        private void button1_Click(object sender, EventArgs e)
        {
    
          textBox1.Text = textBox1.Text.Replace("(", "");
          textBox1.Text = textBox1.Text.Replace(")", "");
          string[] items = textBox1.Text.Split(Environment.NewLine.ToCharArray(), StringSplitOptions.RemoveEmptyEntries);
          Array.Sort<string>(items, 0, items.Length, new Comparer());
          textBox2.Text = String.Join(Environment.NewLine, items);
    
        }
