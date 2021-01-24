    public IEnumerable<string> GetUsedChecklistRecords()
    {
        SelectElement records  = new SelectElement(reportsDr.FindElement(By.XPath("//div[contains(text(),'Benefit Checklist')]")));
        IList<IWebElement> options = records.Options;
        return options.Select(it => it.Text);
     }
     public void ChecklistUsedReportsTest()
     {
         reportsPage.SelectRE("Reporting Entity 02");
         List<String> WorkPaperName = new List<String>(new String[] {"Entertainment","Loan" });
         List<String> reportName = new List<string>(new String[] {"Entertainment Benefit Checklist","Loan Benefit Checklist"});
         var actualRecords= reportsPage.GetUsedChecklistRecords();  
         var areEqual = reportName.All(it => actualRecords.Any(ti => it == ti));   
         List<string> difference = ActualRecords.Except(reportName).ToList();
             
         for (int a = 0; a < WorkPaperName.Count; a++)
         {
             reportsPage.NavigateToChecklist(WorkPaperName[a]);
             foreach (var value in difference)
             {
                 Console.WriteLine(value);
             }
             Console.ReadLine();  
             
         }}
