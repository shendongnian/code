    transaction = con.BeginTransaction();
    string query1 ="Insert Into ABC(NewsCode,Comment) output INSERTED.ID Values (@NewsCode,@Comment)"; 
    cmd = db.GetSqlStringCommand(query1);
    cmd.Transaction = transaction;
    db.AddInParameter(cmd, "NewsCode", DbType.Int32, News.NewsCode);
    db.AddInParameter(cmd, "Comment", DbType.String,News.Comment);
    int modifiedRowId =(int)cmd.ExecuteScalar();
