    public static class Helpers
        {
            private static ILog Log = Global.Log ?? LogManager.GetLogger("MyLogger");
            /// <summary>
            /// Dump contents of a DataTable to the log
            /// </summary>
            /// <param name="table"></param>
            public static void DebugTable(this DataTable table)
            {
                Log?.Debug("--- DebugTable(" + table.TableName + ") ---");
                var nRows = table.Rows.Count;
                var nCols = table.Columns.Count;
                var nMaxColWidth = 32;
    
                // Column Headers
    
                var sColFormat = @"{0,-" + nMaxColWidth + @"} | ";
                var sLogMessage = string.Empty;
                for (var i = 0; i < table.Columns.Count; i++)
                {
                    sLogMessage = string.Concat(sLogMessage, string.Format(sColFormat, table.Columns[i].ToString()));
                }
                //Debug.Write(Environment.NewLine);
                Log?.Debug(sLogMessage);
    
                var sUnderScore = string.Empty;
                var sDashes = string.Empty;
                for (var j = 0; j <= nMaxColWidth; j++)
                {
                    sDashes = sDashes + "-";
                }
    
    
                for (var i = 0; i < table.Columns.Count; i++)
                {
                    sUnderScore = string.Concat(sUnderScore, sDashes + "|-");
                }
    
                sUnderScore = sUnderScore.TrimEnd('-');
    
                //Debug.Write(Environment.NewLine);
                Log?.Debug(sUnderScore);
    
                // Data
                for (var i = 0; i < nRows; i++)
                {
                    DataRow row = table.Rows[i];
                    //Debug.WriteLine("{0} {1} ", row[0], row[1]);
                    sLogMessage = string.Empty;
    
                    for (var j = 0; j < nCols; j++)
                    {
                        string s = row[j].ToString();
                        if (s.Length > nMaxColWidth) s = s.Substring(0, nMaxColWidth - 3) + "...";
                        sLogMessage = string.Concat(sLogMessage, string.Format(sColFormat, s));
                    }
    
                    Log?.Debug(sLogMessage);
                    //Debug.Write(Environment.NewLine);
                }           
                Log?.Debug(sUnderScore);
            }
    }
