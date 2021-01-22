    public class ucFoo : UserControl
    {
        private Panel pnlFoo = new Panel();
        
        public ucFoo()
        {
            this.Controls.Add(pnlFoo);
        }
    }
    public class ucFoo2 : UserControl
    {
        private Panel pnlFooContainer = new Panel();
    
        public ucFoo2()
        {
             this.Controls.Add(pnlFooContainer);
             Thread t = new Thread(new ThreadStart(AddFooControlToFooConatiner());
             t.Start()
        }
        private AddFooControlToFooConatiner()
        {
             ucFoo foo = new ucFoo();
             this.pnlFooContainer.Controls.Add(ucFoo); //<-- this is where the exception is raised
        }
    }
