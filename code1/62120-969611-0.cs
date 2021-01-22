    public static Complaint FromId(int id)
    {
       var command = dataContext.CreateStoreCommand(
                     "dbo.stp_Complaint_Get", 
                     CommandType.StoredProcedure, 
                     new SqlParameter("Id", id));
       return command.Materialize(x =>
                        new Complaint
                        {
                          Id = x.Field<int>("Id"),
                          Transcript = x.Field<string>("Transcript");
                          //... etc. ... Lots more fields from db
                        });
    }
