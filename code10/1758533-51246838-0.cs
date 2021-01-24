    public class Program
        {
            public static void Main(string[] args)
            {
                string myInput = "";
                textBox1.Text.Trim();
                if(textBox1.Text.Length() == 10)
                {
                    if(textBox1.Text[0] == '7')
                    {
                        if(textBox1.Text[1] == '1' || textBox1.Text[1] == '2')
                        {
                            myInput == textBox1.Text();
                            int num = Int32.Parse(myInput);
                            //num is now an int that is 10 digits and starts with "71" or "72"
                        }
                    }
                }
                else
                {
                   MessageBox.Show("Invalid input", "Invalid Input");
                }          
            }
        }
