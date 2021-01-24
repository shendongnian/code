    public class MyReportGenerator : IReportGenerator
    {
        /* implementation here */
    }
    
    public interface IReportGenerator
    {
        byte[] GenerateMyReport(ReportParameters parameters);
    }
    
    [TestMethod]
    public void TestMyReportGenerate()
    {
        //arrange
        var parameters = new ReportParameters(/* some values */);
        var reportGenerator = new MyReportGenerator(/* some dependencies */);
    
        //act
        byte[] resultFile = reportGenerator.GenerateMyReport(parameters);
    
        //assert
        using(var stream = new MemoryStream(resultFile))
        using(var package = new ExcelPackage(stream))
        {
            //now test that it generated properly, such as:
            package.Workbook.Worksheets["Sheet1"].Cells["C6"].GetValue<decimal>().Should().Be(3.14m);
            package.Workbook.Worksheets["Sheet1"].Column(5).Hidden.Should().BeTrue();
        }
    
    }
