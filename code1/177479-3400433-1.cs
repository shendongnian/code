    public void LinqDataSource1_Selecting(object sender, LinqDataSourceSelectEventArgs e)
    {
         var db = new MyDataContext())
         var subjectFilter = e.WhereParameters("Subject");
         var reporters = from spName in db.spReporter()
                         where spName.Subject.Contains(subjectFilter)
                         select new Reporter(spName.Id, spName.InqDate, spName.Subject);
         e.Result = reporters;
    }
