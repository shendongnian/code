    public class ImintMSNRepository : IImintMSNRepository
    {
        public string ConnectionString {get;set;}
        public ImintMSNRepository(string connectionString)
        {
            this.ConnectionString = connectionString;
        }
        
        public bool InsertBulkImportIndexes(DataTable mSNBulkImportIndexTVP, string updatedBy)
        {
            throw new NotImplementedException();
        }
        public bool InsertBulkImportPortfolios(DataTable mSNBulkImportPortfolioTVP, string updatedBy)
        {
            throw new NotImplementedException();
        }
    }
    public class ImintMSNUnitTests
        {
            public readonly IImintMSNRepository MockMSNRepository; //Don't mock this or create read only, this needs to be tested
            public  IImintMSNRepository SUTMSNRepository; //THIS IS SUT SYSTEM UNDER TEST
            //you don't need this constructor as well now
            public ImintMSNUnitTests()
            {
                Mock<IImintMSNRepository> mockRepo = new Mock<IImintMSNRepository>();
                mockRepo.Setup(a => a.InsertBulkImportPortfolios(It.IsAny<DataTable>(), It.IsAny<string>())).Returns(true);
                mockRepo.Setup(b => b.InsertBulkImportIndexes(It.IsAny<DataTable>(), It.IsAny<string>())).Returns(true);
                this.MockMSNRepository = mockRepo.Object;
            }
            [Test]
            public void TestPortfolioSPByMOQ()
            {
                //ARRANGE
                MSNBulkImportPortfolioTVP ptvp = new MSNBulkImportPortfolioTVP();
                DataRow tvprow = ptvp.NewRow();
                tvprow["PortfolioCode"] = "AutomationMoq1";
                tvprow["PortfolioName"] = "AutomationMoqName1";
                tvprow["ClientName"] = "Thomson Reuters";
                tvprow["RIC"] = "IBM.N";
                tvprow["CalculationMethodology"] = "TRGE";
                tvprow["CalendarEventCode"] = "US";
                tvprow["IsProformaPortfolio"] = 1;
                tvprow["IsParentPortfolio"] = 1;
                tvprow["IsGenerateGroupFragment"] = 1;
                tvprow["IsPushLastTick"] = 1;
                ptvp.Rows.Add(tvprow);
                bool expected = true;
                bool actual;
                SUTMSNRepository = new ImintMSNRepository("CONNECTION STRING"); //THIS SHOULD NOT BE A MOCK, THIS SYSTEM UNDER TEST, 
                //MAKE SURE YOU INSTANTIATE THIS AS YOU WANT TO TEST THIS
                //mocking is used mocking the behaviours which is needed to set up the test but not the features you are specifically testing
                //ACT
                actual = this.SUTMSNRepository.InsertBulkImportPortfolios(ptvp, "MSNMoqUnitTestProcess");
                //ASSERT
                Assert.AreEqual(expected, actual);
               //IF ASSERT IS SUCCESSFUL YOU CAN WRITE A CLEANUP METHOD TO REMOVE YOUR UPDATE
            }
        }
