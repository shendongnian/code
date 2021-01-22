    public partial class Window1:Window
    {
        // the property must be public, and it must have a getter & setter
        public Dictionary<string, myClass> myDictionary { get; set; }
        
        public Window1()
        {
            // define the dictionary items in the constructor
            // do the defining BEFORE the InitializeComponent();
            myDictionary = new Dictionary<string, myClass>()
            {
                {"item 1", new myClass(1)},
                {"item 2", new myClass(2)},
                {"item 3", new myClass(3)},
                {"item 4", new myClass(4)},
                {"item 5", new myClass(5)},
            }; 
            InitializeComponent();
        }
    }
