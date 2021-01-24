         using System;
         using System.Collections.Generic;
         using System.Drawing;
         using System.Windows.Forms;
         using System.IO; 
    
         namespace encrypto
         {
           public partial class MainForm : Form
           {
             public MainForm()
             {
    
                InitializeComponent();
    
             }
    
        void OnClick(object sender, EventArgs e)
        {
            string  Plaintext = textBox1.Text;
            string byteText = "";
            byte CipherText;
            if (String.IsNullOrEmpty(textBox1.Text)) 
            {
                MessageBox.Show("Please Enter Text To Be Hidden.", "Error", 
                MessageBoxButtons.OK,    MessageBoxIcon.Warning);
    
            }
    
            for(int i=0; i < Plaintext.Length;i++)
            {
               CipherText = (byte)Plaintext[i];
               byteText += CipherText + " ";     //+= appends text to the string          
            }
               textBox3.Text = string.Format ("{0}",byteText);    //Now that we have all byte text in our string, place it into the textbox.Text property as value
        }
