    public class MyWindow : Window
  
    public MyWindow ()
        {
            InitializeComponent();            
            Closed += new System.EventHandler(MyWindow_Closed);
        }
    private static MyWindow _instance;
    public static MyWindow Instance
    {
        if( _instance == null )
        {
            _instance = new Window();
        }
        return _instance();
    }
    void MyWindow_Closed(object sender, System.EventArgs e)
        {
             _instance = null;
        }
  
