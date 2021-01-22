    class TestBed
    {
        BackgroundWorker bgw = new BackgroundWorker();
        void sample()
        {            
            //approach #1
            bgw.DoWork += new DoWorkEventHandler(bgw_DoWork);
            //DoWorkEventHandler is nothing but a readily available delegate written by smart Microsoft guys
            //approach #2, to make it a little shorter
            bgw.DoWork += (s,e) => 
            {
                //...
            };
            //this is called lambda expression (see the => symbol)
            //approach #3, if lambda scares you
            bgw.DoWork += delegate 
            { 
                //... (but you can't have parameters in this approach
            };
            //approach #4, have a helper method to prepare the background worker
            prepareBgw((s,e)=>
            {
                //...
            }
            );
            //approach #5, helper along with a simple delegate, but no params possible
            prepareBgw(delegate 
            {
                //...
            }
            );
            //approach #6, helper along with passing the methodname as a delegate
            prepareBgw(bgw_DoWork);
            //approach #7, helper method applied on approach #1
            prepareBgw(new DoWorkEventHandler(bgw_DoWork));
        }
        void bgw_DoWork(object sender, DoWorkEventArgs e)
        {
            //...
        }
        void prepareBgw(DoWorkEventHandler doWork)
        {
            bgw.DoWork+= doWork;
        }
    }
