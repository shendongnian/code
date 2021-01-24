    public IEnumerable<string> GetUsedChecklistRecords()
    {
        SelectElement records  = new SelectElement(reportsDr.FindElement(By.XPath("//div[contains(text(),'Benefit Checklist')]")));
        IList<IWebElement> options = records.Options;
        return options.Select(it => it.Text);
     }
     public void ChecklistUsedReportsTest()
     {
         reportsPage.SelectRE("Reporting Entity 02");
         List<String> WorkPaperNames = new List<String>(new String[] {"Entertainment","Loan" });
         List<String> reportNames = new List<string>(new String[] {"Entertainment Benefit Checklist","Loan Benefit Checklist"});
         var actualRecords= reportsPage.GetUsedChecklistRecords();  
         var areEqual = reportNames.All(it => actualRecords.Any(ti => it == ti));   
         List<string> difference = actualRecords.Except(reportNames).ToList();
             
         foreach(var workPaperName in WorkPaperNames)
         {
             reportsPage.NavigateToChecklist(workPaperName);
             foreach (var value in difference)
             {
                 Console.WriteLine(value);
             }
             Console.ReadLine();  
             
         }}
