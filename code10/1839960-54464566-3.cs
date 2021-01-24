        using (var db = new Db())
        {
            db.Database.OpenConnection();
            var con = (SqlConnection)db.Database.GetDbConnection();
            var cmd = con.CreateCommand();
            //...
        }
