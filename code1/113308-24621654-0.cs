    public class MyUserControl: UserControl
    {
        ...
        
        private List<MyObject> myObjects = null;
        private List<MyObject> MyObjects 
        { 
            get
            {
                if (myObjects == null)
                {
                    // lazy initialisation here
                    using (var dbContext = new MyVerySpecialDatabaseContext())
                    {
                        myObjects = dbContext.MyObjects.ToList();
                    }
                }
                return myObjects;
            }
        }
            
        public MyUserControl()
        {
            InitializeComponent();
          
            this.Load += new System.EventHandler(this.MyUserControl_Load);
          
            ... // more UI initialization, but no complicated logic here
        }
      
        private void MyUserControl_Load(object sender, EventArgs e)
        {
            this.myDataBindingSource.DataSource = MyObjects;
        }
    }
