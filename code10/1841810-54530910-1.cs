    public partial class Form1 : Form
    {
        // Here declare a variable visible to all methods inside the class but 
        // not outside the class. Init it with an empty string
        private string theFile = "";
        private void button1_Click(object sender, EventArgs e)
        {
            // When you click the button1 check if the class level variable 
            // has been set to something in the button3 click event handler
            if(string.IsNullOrEmpty(theFile) || !File.Exists(theFile))
                return;
            // Now you can use it to load the file and continue with the code
            // you have already written
            byte[] bytes = File.ReadAllBytes(theFile);
            ......
            ......
        }
        private void button3_Click(object sender, EventArgs e)
        {
            // The only job of button3 is to select the file to work on
            // as you can see we can use the class level variable also here
            var FD = new System.Windows.Forms.OpenFileDialog();
            if (FD.ShowDialog() == System.Windows.Forms.DialogResult.OK)
                theFile = FD.FileName;
        }
    }
