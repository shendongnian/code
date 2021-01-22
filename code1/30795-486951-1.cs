    internal class TestMethodCommandClass
    {
        public static IEnumerable<object[]> EmptyData
        {
            get { return new object[0][]; }
        }
        public static IEnumerable<object[]> NullData
        {
            get { return null; }
        }
        public static IEnumerable<object[]> TheoryDataProperty
        {
            get { yield return new object[] { 2 }; }
        }
        [Theory, PropertyData("EmptyData")]
        public void EmptyDataTheory() { }
        [Theory, PropertyData("NullData")]
        public void NullDataTheory() { }
        [Theory, OleDbData(
            @"Provider=Microsoft.Jet.OleDb.4.0; Data Source=DataTheories\UnitTestData.xls; Extended Properties=Excel 8.0",
            "SELECT x, y, z FROM Data")]
        public void TestViaOleDb(double x,
                                 string y,
                                 string z) { }
        [Theory, PropertyData("TheoryDataProperty")]
        public void TestViaProperty(int x) { }
        [Theory, ExcelData(@"DataTheories\UnitTestData.xls", "SELECT x, y, z FROM Data")]
        public void TestViaXls(double x,
                               string y,
                               string z) { }
    }
