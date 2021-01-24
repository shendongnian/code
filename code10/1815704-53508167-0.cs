    private void button1_Click(object sender, EventArgs e)
        {
            string searchString = "Item 3";
            Random rdn = new Random();
    
            while (LB_1.Items.Count > 0)
            {
                int rnd = rdn.Next(0, LB_1.Items.Count);
                if (LB_1.Items[rnd].ToString() != searchString) LB_2.Items.Add(LB_1.Items[rnd]);
                LB_1.Items.RemoveAt(rnd);
            }
        }
