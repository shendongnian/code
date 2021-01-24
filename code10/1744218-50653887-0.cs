    try {
        using(var db = new DatabaseContext()) {
            db.SaveChanges();
        }
    }
    catch(UpdateException ex) {
        var sqlException = ex.InnerException as SqlException;        
        if(sqlException != null && sqlException.Errors.OfType<SqlError>()
            .Any(se=>se.Number == 2601 || se.Number == 2627 /* primary key/unique key constraint violation */)) {            
            // handle duplicate
        }
    }
