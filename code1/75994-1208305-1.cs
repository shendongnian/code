    [Test]
    public void ShouldCallCorrectProcWithParams()
    {
        var mockTrx = new Mock<IDbTransaction>();
        mockTrx.Setup(txn => txn.Connection.CreateCommand()).Returns(new SqlCommand());
    
        var dbUtil = new Mock<IDbUtility>();
        dbUtil.Setup(exec => exec.ExecuteScalar(
                                 It.Is<SqlCommand>(
                                 cmd => cmd.CommandText == "somecmdtext"
                                 && cmd.Parameters.Count == 1
                                 && cmd.Parameters[0].ParameterName == "ParamName")))
                     .Returns(DateTime.Now);
    
         var session = new Session {dbUtility = dbUtil.Object};
    
         session.MyMethod(mockTrx.Object, DateTime.Now);
    
         mockTrx.VerifyAll();
         dbUtil.VerifyAll();
                
    }
