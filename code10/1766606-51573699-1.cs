    [HttpGet("api/recent-reports")]
    public async Task<ActionResult> GetStatusSummaryRecentReports()
    { 
       // When you call your class that has your Business logic, make it as async task pattern as well, so you will call it using the await keyword such as:
      // MyBusinessLogicClass resultFromBll = new MyBusinessLogicClass();
      // var getResult = await resultFromBll.MethodGroupByMonthAndSum();
       ...your controller code here...
    }
