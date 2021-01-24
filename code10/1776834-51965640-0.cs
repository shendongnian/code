     public void Test_Report_01()
     {
         try{
             #region Fetch data from Excel file
    
            string fromDate = Convert.ToString(TestContext.DataRow["From date"]);
            string startDate = Convert.ToString(TestContext.DataRow["Report period start date"]);
            string toDate = Convert.ToString(TestContext.DataRow["To date"]);
    
            #endregion Fetch data from Excel file
    
            Application.Control.TextBox().SetValue(fromDate);
         }
         catch(Exception e){
             Console.WriteLine(e.toString());
         }
    }
