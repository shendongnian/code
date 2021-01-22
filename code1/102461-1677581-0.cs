    ISQLQuery sqlQuery1 = NHibernateSessionManager.Instance.GetSession().CreateSQLQuery("select Match.ID, sum(Game.Score) as total from Game inner join Match on Game.Match_ID = Match.ID group by match.ID order by total desc");
    sqlQuery1.AddScalar("id", NHibernateUtil.Int32); //
    sqlQuery1.AddScalar("total", NHibernateUtil.Int32);
    sqlQuery1.SetMaxResults(1);    
    var result = sqlQuery1.List();
