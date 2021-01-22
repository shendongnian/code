    public void Test(TestEntity TestEntity)
            {           
      IQuery query = NHSession.CreateSQLQuery("exec LogData :Time, :Data");
                query.SetParameter("Time", TestEntity.Time);
                query.SetParameter("Data", TestEntity.Data);
                object obj = query.UniqueResult();
            }
