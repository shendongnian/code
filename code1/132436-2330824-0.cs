        private void button1_Click(object sender, EventArgs e)
        {
            textBox2.Lines = textBox1.Lines.OrderBy(x => x,new Comparer()).ToArray();
        }
        public class Comparer : IComparer<string>
        {
            public int Compare(string x, string y)
            {
                //logic here
                return 0;
            }
        }
