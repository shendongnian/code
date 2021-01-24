        // The following is SSRS boiler-plate from Microsoft
    string encoding = null;
    Warning[] warnings = null;
    string[] streamIDs = null;
    ExecutionInfo execInfo = new ExecutionInfo();
    ExecutionHeader execHeader = new ExecutionHeader();
    rexec.ExecutionHeaderValue = execHeader;
    execInfo = rexec.LoadReport(reportPath, historyID);
    rexec.SetExecutionParameters(parameters, "en-us");
    Console.WriteLine("SessionID: {0}", rexec.ExecutionHeaderValue.ExecutionID);
    try
    {
         Console.WriteLine(reportName.ToString());
         result = rexec.Render(format, devInfo, out string extension, out string 
            mimeType, out encoding, out warnings, out streamIDs);
    execInfo = rexec.GetExecutionInfo(); Console.WriteLine("Execution date and time: 
            {0}", execInfo.ExecutionDateTime);
    }
    catch (SoapException e)
    {
        Console.WriteLine(e.Detail.OuterXml);
        Dts.Events.FireError(0, "Error ",e.Message+ "\r" + e.StackTrace, String.Empty,0);
        Dts.TaskResult = (int)ScriptResults.Failure;
     }
