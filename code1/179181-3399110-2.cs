    public List<Inquiry> GetInquiries(IReportReposSpec spec)
    {
          var cmd = new SqlCommand();
          cmd.CommandType = CommandType.StoredProcedure;
          
          // for simplicity i'm going to use a pseudo code from here on
          cmd.AddParam(spec.Param, spec.DbType, spec.Value));
          
          //...
    }
