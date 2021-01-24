    private ConcurrentDictionary<string,bool> _dict = new ConcurrentDictionary<string,bool>();
    
    ...
    
    using (DataTable schools = new DataTable { TableName = "Schools" })
    {
       schools.ReadXml(AppSettings.Default.SettingsPath);
    
       try
       {
          Parallel.ForEach(schools.AsEnumerable(), _opts, row =>
          {
             var ipAddress = row.Field<string>("IPAddress");
    
             // check if there is an ip registered and if its processing
             if (_dict.TryGetValue(ipAddress, out processing) && processing)
                return;
    
              // its not processing ,so update it
             _dict.AddOrUpdate(ipAddress, true, (s, b) => true);
    
             SchoolFunctions.Backup(ipAddress , row.Field<string>("Name"));
    
             // when we are done update processing to false
             _dict.AddOrUpdate(ipAddress, false, (s, b) => false);
    
          }
       }
    }
