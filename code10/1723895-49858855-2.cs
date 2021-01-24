        public partial class Form4 : Form
        {
           private void button1_Click_1(object sender, EventArgs e)
           {
             var form3 = Application.OpenForms["Form3"];
             form3.label2.Text = "You pressed button 1";
           }
    
           private void button2_Click_1(object sender, EventArgs e)
           {
             var form3 = Application.OpenForms["Form3"];
             form3.label2.Text = "You pressed button 2";
           }
        }
