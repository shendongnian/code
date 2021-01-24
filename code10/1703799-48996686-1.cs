    class SomeForm : Form
    {
        public Form_Load(object sender, EventArgs e)
        {
            Panel panel1 = new Panel
            {
                Name = "SomeNameICanUse", //Important!
                BackColor = Color.Red,
                Location = new Point(0, 0),
                Size = new Size(320, 480)
            };
            this.Controls.Add(panel1);
        }
        public void Example()
        {
            var panel1 = this.Controls.Find("SomeNameICanUse") as Panel; //use the name to find it
            if (panel1 != null) panel1.BackColor = Color.Blue; 
        }
    }
