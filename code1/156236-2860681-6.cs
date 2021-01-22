    public struct Polynomial
    {
        public int Coefficient;
        public int Power;
        public Polynomial? Link;
    }
    private Polynomial? start;
    private void button1_Click(object sender, EventArgs e)
    {
        string holder = String.Empty;
        start = new Polynomial();
        int i = 0;
        while (this.textBox1.Text[i] != ',')
        {
            holder += this.textBox1.Text[i];
            i++;
        }
        start.Value.Coefficient = Int32.Parse(holder);
        i++;
        holder = String.Empty;
        while (this.textBox1.Text[i] != ';')
        {
            holder += this.textBox1.Text[i];
            i++;
        }
        start.Value.Power = Int32.Parse(holder);
        Polynomial? p = start;
        //creation of the first node finished!
        i++;
        for (; i < this.textBox1.Text.Length; i++)
        {
            Polynomial? test = new Polynomial();
            holder = String.Empty;
            while (this.textBox1.Text[i] != ',')
            {
                holder += this.textBox1.Text[i];
                i++;
            }
            test.Value.Coefficient = Int32.Parse(holder);
            i++;
            holder = String.Empty;
            while (this.textBox1.Text[i] != ';' && i < this.textBox1.Text.Length - 1)
            {
                holder += this.textBox1.Text[i];
                if (i < this.textBox1.Text.Length - 1)
                    i++;
            }
            test.Value.Power = Int32.Parse(holder);
            p.Value.Link = test;    //the addresses are correct and the list is complete
            p = test;
        }
    }
