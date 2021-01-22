     public partial class Sheet1
     {
         private void Sheet1_Startup(object sender, System.EventArgs e)
         {
            var button = this.Controls.AddButton(10, 10, 50, 50, "My Button");
            button.Text = "My Button";
            button.Click += new EventHandler(button_Click);
         }
    
         void button_Click(object sender, EventArgs e)
         {
            MessageBox.Show("I was clicked!");
         }
