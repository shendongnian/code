    namespace ConsoleApp1
    {
        public class TextInput
        {
            protected string _text = "";
            //Virtual allows derived class to enhance its functionality.
            public virtual void Add(char c)
            {
                _text += c;
            }
            ....
        }
    
    
        public class NumericInput : TextInput
        {
            //Override function will add more functionality to base class function
            @override  
            public override void Add(char c)
            {
                if (!char.IsDigit(c)) return;
                _text += c;
            }
        }
