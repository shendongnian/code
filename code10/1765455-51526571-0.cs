    public class Form1 : Form
    {
        private Class1 multiplyer;
        public Form1()
        {
            this.multiplyer = new Class1(); // one single instance of Class1 shared between everything inside Form1
        }
        private void UserInput_TextChanged(object sender, EventArgs e)
        {
           this.multiplyer.NumberOne = int.Parse(UserInput.Text);  
        }
        // ...
        private void Okay_Click(object sender, EventArgs e)
        {
           MessageBox.Show(this.multiplyer.Multiply().ToString());  
        }
    }
