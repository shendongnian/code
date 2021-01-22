    public static void DebugDataSet ( string msg, ref System.Data.DataSet ds )
    {
        WriteIf ( "===================================================" + msg + " START " );
        if (ds != null)
        {
            WriteIf ( msg );
            foreach (System.Data.DataTable dt in ds.Tables)
            {
                WriteIf ( "================= My TableName is  " +
                dt.TableName + " ========================= START" );
                int colNumberInRow = 0;
                foreach (System.Data.DataColumn dc in dt.Columns)
                {
                    System.Diagnostics.Debug.Write ( " | " );
                    System.Diagnostics.Debug.Write ( " |" + colNumberInRow + "| " );
                    System.Diagnostics.Debug.Write ( dc.ColumnName + " | " );
                    colNumberInRow++;
                } //eof foreach (DataColumn dc in dt.Columns)
                int rowNum = 0;
                foreach (System.Data.DataRow dr in dt.Rows)
                {
                    System.Diagnostics.Debug.Write ( "\n row " + rowNum + " --- " );
                    int colNumber = 0;
                    foreach (System.Data.DataColumn dc in dt.Columns)
                    {
                        System.Diagnostics.Debug.Write ( " |" + colNumber + "| " );
                        System.Diagnostics.Debug.Write ( dr[dc].ToString () + " " );
                        colNumber++;
                    } //eof foreach (DataColumn dc in dt.Columns)
                    rowNum++;
                }	//eof foreach (DataRow dr in dt.Rows)
                System.Diagnostics.Debug.Write ( " \n" );
                WriteIf ( "================= Table " + dt.TableName + " ========================= END" );
                WriteIf ( "===================================================" + msg + " END " );
            }	//eof foreach (DataTable dt in ds.Tables)
        } //eof if ds !=null 
        else
        {
            WriteIf ( "NULL DataSet object passed for debugging !!!" );
        }
    } //eof method 
    public static void WriteIf ( string msg )
    {
        //TODO: FIND OUT ABOUT e.Message + e.StackTrace from Bromberg eggcafe
	int output = System.Convert.ToInt16(System.Configuration.ConfigurationSettings.AppSettings["DebugOutput"] );
        //0 - do not debug anything just run the code 
	switch (output)
	{
	    //do not debug anything	
	    case 0:
	        msg = String.Empty;
		break;
            //1 - output to debug window in Visual Studio 		
            case 1:
                System.Diagnostics.Debug.WriteIf ( System.Convert.ToBoolean( System.Configuration.ConfigurationSettings.AppSettings["Debugging"] ), DateTime.Now.ToString ( "yyyy:MM:dd -- hh:mm:ss.fff --- " ) + msg + "\n" );
                break;
            //2 -- output to the error label in the master 
            case 2:
                string previousMsg = System.Convert.ToString (System.Web.HttpContext.Current.Session["global.DebugMsg"]);
                System.Web.HttpContext.Current.Session["global.DebugMsg"] = previousMsg +
                DateTime.Now.ToString ( "yyyy:MM:dd -- hh:mm:ss.fff --- " ) + msg + "\n </br>";
                break;
            //output both to debug window and error label 
            case 3:
                string previousMsg1 = System.Convert.ToString (System.Web.HttpContext.Current.Session["global.DebugMsg"] );
                System.Web.HttpContext.Current.Session["global.DebugMsg"] = previousMsg1 + DateTime.Now.ToString ( "yyyy:MM:dd -- hh:mm:ss.fff --- " ) + msg + "\n";
                System.Diagnostics.Debug.WriteIf ( System.Convert.ToBoolean( System.Configuration.ConfigurationSettings.AppSettings["Debugging"] ), DateTime.Now.ToString ( "yyyy:MM:dd -- hh:mm:ss.fff --- " ) + msg + "\n </br>" );
                break;
            //TODO: implement case when debugging goes to database 
        } //eof switch 
    } //eof method WriteIf
