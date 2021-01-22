    public partial class Form1 : Form 
    { 
        private void button1_Click_1(object sender, EventArgs e) 
        { 
            class1 l_objClass1 = new class1();
            l_objClass1.FileRead += 
                delegate { lblStatus.Text = "File Read..."; };
            l_objClass1.FileParsed += 
                delegate { lblStatus.Text = "File Parsed..."; };
            l_objClass1.FileSaved += 
                delegate { lblStatus.Text = "File Saved..."; };
            l_objClass1.DoOperation(); 
        } 
    } 
