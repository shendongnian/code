        [TestInitialize]
        public void Setup()
        {
            string spreadsheet = Path.GetFullPath("test.xlsx");
            Assert.IsTrue(File.Exists(spreadsheet));
            ...
        }
        [TestMethod]
        [DeploymentItem("test.xlsx")]
        public void ExcelQuestionParser_Reads_XmlElements()
        {
            ...
        }
