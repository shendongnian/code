    public class Dogs
    {
        // global variable to hold form1
        public Form1 MyForm1;
        public Dogs(Form1 form1Istance)
        {
            this.MyForm1 = form1Istance;
        }
    
        public void showTextBox1Text()
        {
             // do not forget to set the access modifier of TextBox1 to public (you can do it in the Designer, the propery is "Modifier")
            System.Windows.Forms.MessageBox.Show("showTextBox1Text(): " + this.MyForm1.textBox1.Text);
        }
    
        public void passedTextFromForm1(string txtfromtextbox1)
        {
            // another way to share data between instances
            System.Windows.Forms.MessageBox.Show("passedTextFromForm1(): " + txtfromtextbox1);
        }
    }
