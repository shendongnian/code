    public partial class TestTab : UserControl
    {
        public TestTab()
        {
            InitializeComponent();	// the standard bit
		
	    // then we set the DataContex of TestTab Control to a MyViewModel object
	    // this MyViewModel object becomes the DataContext for all controls
             // within TestTab ... including our CheckBox
             DataContext = new MyViewModel(....);
        }
		
    }
 
