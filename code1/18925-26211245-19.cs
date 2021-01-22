    public class Button
    {
        private string _text;        
        private string _name;
        private string _someProperty;
        public string Text
        {
            get
            {
               return _text;
            }
            set
            {
               _text = value;
            }
       } 
       public string Name
       {
            get
            {
               return _name;
            }
            set
            {
               _name = value;
            }
       } 
       [Browsable(false)]
       public string SomeProperty
       {
            get
            {
               return _someProperty;
            }
            set
            {
               _someProperty= value;
            }
       } 
  
