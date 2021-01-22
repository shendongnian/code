       var actual = Get();
       using (var db = new DataClassesDataContext())
       {
           foreach(var batch in actual.Chunk(5))
           {
             db.Shapes.InsertAllOnSubmit(batch);
             db.SubmitChanges();
           }
       }
