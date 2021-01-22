    {
        public Tester()
        {
            SiteEventArgs ar = new SiteEventArgs("MeSite");
            base.Completed += new CompletedCallback(Tester_Completed);
        }
        void Tester_Completed(WebBrowser wb)
        {
            MessageBox.Show("Tester");
            if( wb.DocumentTitle == "Hi")
                
            base.mSyncProvider_Completed(wb);
        }
        
       
        //protected override void mSyncProvider_Completed(WebBrowser wb)
        //{
        //  //  MessageBox.Show("overload Tester");
        //    //base.mSyncProvider_Completed(wb, ar);
        //}
    }
