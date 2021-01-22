        public override void EndInit()
        {
            base.EndInit();
            Adapter.RowUpdated += 
                       new System.Data.Odbc.OdbcRowUpdatedEventHandler(OnRowUpdated);
    
        }
        void OnRowUpdated(object sender, System.Data.Odbc.OdbcRowUpdatedEventArgs e)
        {
        }
