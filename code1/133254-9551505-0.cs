    private void button1_Click(object sender, EventArgs e)
    {
         Form2 form2 = new Form2();
         this.Controls.Clear();
         foreach(Control c in this.Controls)
         {
             this.Controls.Add(c);
         }
    }
