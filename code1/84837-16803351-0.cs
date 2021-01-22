    public partial class Form1 : Form
    {
            //create a global private integer 
            private int number;
    
            public Form1()
            {
                InitializeComponent();
                //Intialize the variable to 0
                number = 0;
                //Probably a good idea to intialize the label to 0 as well
                numberLabel.Text = number.ToString();
            }
            private void Xbutton_Click(object sender, EventArgs e)
            {
                //On a X Button click increment the number
                number++;
                //Update the label. Convert the number to a string
                numberLabel.Text = number.ToString();
            }
            private void Ybutton_Click(object sender, EventArgs e)
            {
                //If number is less than or equal to 0 pop up a message box
                if (number <= 0)
                {
                    MessageBox.Show("Cannot decrement anymore. Value will be  
                                                    negative");
                }
                else
                {
                    //decrement the number
                    number--;
                    numberLabel.Text = number.ToString();
                }
            }
        }
