    public partial class MyUserControl : UserControl
    {
    	private int _parm1;
    	private string _parm2;
    	
    	private MyUserControl()
        {
            InitializeComponent();
        }
    	
        public MyUserControl(int parm1, string parm2) : this()
        {
            _parm1 = parm1;
    		_parm2 = parm2;
        }
    }
