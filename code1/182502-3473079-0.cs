public class TestClass
{
    public DateTime Date { get; set; }
    public IEnumerable&lt;My_SiteReportResult&gt; Reports {get;set;}
}
public class UIDateAndReport
{
    public DateTime Date { get; set; }
    public My_SiteReportResult Report { get; set; }
}
TestClass tst = new TestClass();
...
var DatedReports =
        (from r in tst.Reports
         select new UIDateAndReport { Date = tst.Date, Report = r });
</pre>
