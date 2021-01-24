    void WaitAndPrint(TestController.TestReportModel report)
    {
        //Create Thread
        Thread thread = new Thread(delegate ()
        {
            dbHelper.deleteAllFromTable(dbHelper.TABLE_OFFLINE_MASTER_TEST_REPORT);
            dbHelper.deleteAllFromTable(dbHelper.TABLE_MASTER_OFFLINE_POINT_DATA);
    
            for (int i = 0; i < report.data.Count; i++)
            {
                TestController.TestData MasterData = report.data[i];
                dbHelper.AddOfflineMasterTestReport(MasterData, "");
            }
        });
        //Start the Thread and execute the code inside it
        thread.Start();
    }
