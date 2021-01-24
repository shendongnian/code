    public static void SetSingleToDatabase(Record record)
            {
                record.Updated = DateTime.UtcNow;
    
                var context = new DbContext("MyEntities");
                var recordById = context.GetById(x=>x.record.Id)
                //now manualy you must assign recordById = record
                var db = context.Set<recordById >();
                db.AddOrUpdate(recordById );
                context.SaveChanges();
            }
