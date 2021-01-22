    string sql = @"UPDATE tblContent 
    						SET Title = @Title, Content = @Content, IsPublic = @IsPublic, ItemOrder = @ItemOrder
    						WHERE ContentItemID = @ContentItemID";
    
    Database db = DatabaseFactory.CreateDatabase();
    using(DbCommand cmd = db.GetSqlStringCommand(sql))
    {
    	db.AddInParameter(cmd, "Title", DbType.String, title);
    	db.AddInParameter(cmd, "Content", DbType.String, content);
    	db.AddInParameter(cmd, "IsPublic", DbType.Boolean, isPublic);
    	db.AddInParameter(cmd, "ItemOrder", DbType.Int32, itemOrder);
    	db.AddInParameter(cmd, "ContentItemID", DbType.Int32 , contentItemID);
    
    	db.ExecuteNonQuery(cmd);
    }
