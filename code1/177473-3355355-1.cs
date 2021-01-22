        public List<Reporter> GetInquiries()
        {
            using (MyDataContextDataContext dc = conn.GetContext())
            {
                return (from spName in dc.spReporter()
                        select new Reporter(spName.Id, spName.InqDate, spName.Subject)).ToList()
            }      
