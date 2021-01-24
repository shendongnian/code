        private void button1_Click(object sender, EventArgs e)
        {
            panda p = new panda(Image.FromFile("C:\\Users\\hsnha\\OneDrive\\Desktop\\Panda.png"), new Rectangle(20, 20, 70, 70));
            pandas.Add(p);
        }
        private void timer1_Tick(object sender, EventArgs e)
        {
            foreach (panda p in pandas)
            {
                Rectangle rect = p.rect_panda;
                // Fix the rect like before
            }
        }
