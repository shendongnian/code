    private ICollection<object> ScanInternal(string path)
    {
         List<object> result = new List<object>();
         MethodInfo GetReports = 
               _reportFactoryType.GetMethod("GetAllReportsInstalled");
         IEnumerable reports = GetReports.Invoke(_reportFactory, null)
               as IEnumerable;
         if (reports != null)  // or exception if null ?
         {
             foreach (object report in reports)
                 result.Add(report);
         }
         return result;
    }
