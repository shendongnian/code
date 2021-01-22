    {
        public Window1()
        {
            InitializeComponent();
        
            //create new  object
            BackgroundObject bo = new BackgroundObject();
                
            //binding only needed for the text box to change speed value
            this.DataContext = bo;
    
            //Hook up event
            bo.SpeedChanged += bo_SpeedChanged;
                
            //Needed to prevent an error
            Storyboard sb = (Storyboard)rc.FindResource("spin");
            sb.Begin(); 
        }
    
        //Change Speed
        public void bo_SpeedChanged(  object sender, int newSpeed)
        {
            Storyboard sb = (Storyboard)rc.FindResource("spin");
            sb.SetSpeedRatio(newSpeed);
        }
    }
    
    public delegate void SpeedChangedEventHandler(object sender, int newSpeed);
    public class BackgroundObject
    {
        public BackgroundObject()
        {
            _speed = 10;
        }
            
        public event SpeedChangedEventHandler SpeedChanged;
    
        private int _speed;
        public int Speed
        { 
            get { return _speed; }
            set { _speed = value; SpeedChanged(this,value); }
        }
    }
