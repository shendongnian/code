     public partial class form1 : Form
        {
    
     MouseClick1 button1 = new MouseClick1();
     MouseClick1 button2 = new MouseClick1();
[...]
        public void Simulate_button1and2_Click(object sender, EventArgs e)
        {
           button1.CoordX = 1652;   //random coordinates
           button1.CoordY = 225;
           button2.CoordX = 1650;
           button2.CoordY = 250;
           button1.Click1();
           button1.Click2();
