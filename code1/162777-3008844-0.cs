        private void button2_Click(object sender, EventArgs e)
        {
            string s = "AAABBBCCC";
            string[] a = SplitByLenght(s,3);
        }
        private string[] SplitByLenght(string s, int split)
        {
            //Like using List because I can just add to it 
            List<string> list = new List<string>();
                        // Integer Division
            int TimesThroughTheLoop = s.Length/split;
            
            for (int i = 0; i < TimesThroughTheLoop; i++)
            {
                list.Add(s.Substring(i * split, split));
            }
            // Pickup the end of the string
            if (TimesThroughTheLoop * split != s.Length)
            {
                list.Add(s.Substring(TimesThroughTheLoop * split));
            }
            return list.ToArray();
        }
      
