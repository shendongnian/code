     using System.Windows.Forms;
     namespace WindowsFormsApp1 {
     public partial class Form1 : Form
     {
         public Form1()
         {
             InitializeComponent();
         }
 
         private void textBox1_KeyPress(object sender, KeyPressEventArgs e)
         {
             if(e.KeyChar == 13) //checks if "enter" was pressed
             {
                 listBox1.Items.Add(textBox1.Text);//adds the text to the list
                 textBox1.Clear(); //clear the text of the textbox
             }
         }
     } }
