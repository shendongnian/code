    public delegate void doupdate();
            public void UpdateLabel()
            {
                doupdate db = new doupdate(DoUpdateLabel);
                this.Invoke(db);
            }
    
            public void DoUpdateLabel()
            {
                toolStripStatusLabel1.Text = timeelepse;
            }
