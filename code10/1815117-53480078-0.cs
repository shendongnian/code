    dbConnection.Open();
    return dbConnection.Query<TradeDetail, TradeComment, TradeDetail>("wwr.pMyProc",
            (detail, comment) =>
            {
                detail.TradeComment = comment;
                return detail;
            }, 
            splitOn: "TradeCommentId", 
            param: new {id = id }, 
            commandType: CommandType.StoredProcedure);
     }
