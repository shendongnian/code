    // Using and namespace...
    
    public partial class FormOptions : Form
    {
        private string _MyString;    //  Use this
        public string MyString {     //  in 
          get { return _MyString; }  //  .NET
        }                            //  2.0
        public string MyString { get; } // In .NET 3.0 or newer
    
        // The rest of the form code
    }
