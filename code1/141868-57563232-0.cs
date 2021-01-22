`
private static void SaveAs(string sourceFilePath, string targetFilePath)
{
	Application application = null;
	Workbook wb = null;
	Worksheet ws = null;
	try
	{
		application = new Application();
		application.DisplayAlerts = false;
		wb = application.Workbooks.Open(sourceFilePath);
		ws = (Worksheet)wb.Sheets[1];
		ws.SaveAs(targetFilePath, XlFileFormat.xlUnicodeText);
	}
	catch(Exception e)
	{
		Console.WriteLine($"Error while saving: {e}");
	}
	finally
	{
		if (application != null) application.Quit();
		if (ws != null) Marshal.ReleaseComObject(ws);
		if (wb != null) Marshal.ReleaseComObject(wb);
		if (application != null) Marshal.ReleaseComObject(application);
	}
}
`
