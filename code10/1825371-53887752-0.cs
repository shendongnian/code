    public class A : Form1
    {
        // assuming it's a string. If it's not, change the type
        // for the getter method below accordingly
        private string textBoxValue;
        // at some point, you'll have to make this line below:
        textBoxValue = textBox1.Value;
        public string GetTextBoxValue()
        {
            return textBoxValue;
        }
    }
   
    public class B 
    {
        A aReference = new A();
  
       // you can get the value you want by doing
       // aReference.GetTextBoxValue();
    }
