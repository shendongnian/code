    int[] totX = new int[3];
        string[] navX = new string[] {"test1", "test2", "test3"};
       
        public Form1()
        {
            
            for (int i = 0; i < 3; i++)
            {
                using (StreamReader sr = new StreamReader(@"c:\temp\output.txt"))
                {
                    
                    var total = 0;
                    while (!sr.EndOfStream)
                    {
                        var counts = sr
                            .ReadLine()
                            .Split('"')
                            .GroupBy(s => s)
                            .Select(g => new { Word = g.Key, Count = g.Count() });
                        var wc = counts.SingleOrDefault(c => c.Word == navX[i]);
                        total += (wc == null) ? 0 : wc.Count;
                        totX[i] = total;
                    }
                } 
            }
           
            InitializeComponent();
        }
        private void button1_Click(object sender, EventArgs e)
        {
            textBox1.Text = totX[0].ToString();
            textBox2.Text = totX[1].ToString();
            textBox3.Text = totX[2].ToString();
        }
    }
