        internal bool UpdatingValue { get; set; }
        partial void OnValueChanged()
        {
            if (UpdatingValue) return;
            MyAppDataContext dc = new MyAppDataContext();
            var q = from o in dc.GetTable<Things>() where o.Id == 13 select o;
            foreach (Things o in q)
            {
                o.UpdatingValue = true;
                o.Value = "1";  // try to change some other row
                o.UpdatingValue = false;
            }
            try
            {
                dc.SubmitChanges();
            }
            catch (Exception)
            {
                // SQL timeout occurs 
            }
        }
    }
