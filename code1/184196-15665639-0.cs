        [TestMethod]
        public void FooRepo_CallsCorrectSPOnDatabase()
        {
            Castle.DynamicProxy.Generators.AttributesToAvoidReplicating.Add(typeof(System.Data.SqlClient.SqlClientPermissionAttribute));
            var mockSqlDb = new Mock<SqlDatabase>("fake connection string");
            mockSqlDb.Setup(s => s.GetStoredProcCommand("sp_GetFoosById"));
            var sut = new FooRepository(mockSqlDb);
            sut.LoadFoosById(1);
            mockSqlDb.Verify(s => s.GetStoredProcCommand("sp_GetFoosById"), Times.Once(), "Stored Procedure sp_GetFoosById was not invoked.");
        }
