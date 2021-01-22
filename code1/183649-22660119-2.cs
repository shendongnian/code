    public  string GetNumberOFWorkDays(Guid leaveID)
    {
      using (var ctx  = new INTERNAL_IntranetDemoEntities())
      {
        return ctx.
        ExecuteStoreQuery<string>
         ("SELECT [dbo].[fnCalculateNumberOFWorkDays](@leaveID)",
        new SqlParameter { ParameterName = "leaveID", Value = leaveID })
                  .FirstOrDefault();
       }
    }
