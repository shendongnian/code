       public partial class Form1 : Form
        {
            private Label[] labels;
            private ComboBox[] combos;
            private Random r = new Random();
            SortedList<string, string> sl = new SortedList<string, string>();
    
            public Form1()
            {
                InitializeComponent();
            }
    
            private void Form1_Load(object sender, EventArgs e)
            {
                labels = new Label[]{ label1, label2, label3 };
                combos = new ComboBox[]{ comboBox1, comboBox2, comboBox3 };
                sl.Add("Key1", "Value1");
                sl.Add("Key2", "Value2");
                sl.Add("Key3", "Value3");
                sl.Add("Key4", "Value4");
                sl.Add("Key5", "Value5");
    
                HashSet<int> used = new HashSet<int>();
                foreach (Label l in labels)
                {
                    int n = r.Next(0, sl.Count);
                    while(used.Contains(n))
                       n = r.Next(0, sl.Count);
                    used.Add(n);
                    l.Text = sl.ElementAt(n).Key;
                }
                foreach(ComboBox combo in combos)
                {
                    foreach(string s in sl.Values)
                    {
                        combo.Items.Add(s);
                    }
                }
    
            }
    
            private void button1_Click(object sender, EventArgs e)
            {
                int nCorrect = 0;
                
                for(int n = 0; n < labels.Length; n++)
                {
                    if(combos[n].Text == sl[labels[n].Text])
                    {
                        nCorrect++;
                    }
                            
                }
                labelScore.Text = nCorrect.ToString();
            }
        }
