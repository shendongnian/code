        [TestMethod()]
        [ExpectedException(typeof(Exception))]
        public void UpdateCaseErrorTest()
        {
            var repository = new Mock<IDataContext>();
            var errorLoggerRepository = new Mock<IExceptionLogger>();
            var serviceRepository = new Mock<IServiceInterface>();
            repository.Setup(m => m.Get()).Returns(new 
            ManualWithDrawDataContext());
            repository.Setup(m => m.GetCouncilRefundRecord())
             .Returns(new LinqToSQLModelName
             {
                 refrence= "10",
                 Reason = "Reason",
                 DateCaptured = DateTime.Now,
             });
            var sut = new DataContext(repository.Object.Get(), serviceRepository.Object, errorLoggerRepository.Object);
             sut.UpdateCase(repository.Object.GetCouncilRefundRecord(), null);//This null allows me to go to the catch
             Assert.IsFalse(sut.Result);
        }
