    private string GetDriveLabelFromAutorunInf(string drivename)
        {
            try
            {
                string filepathAutorunInf = Path.Combine(drivename, "autorun.Inf");
                string stringInputLine = "";
                if (File.Exists(filepathAutorunInf))
	            {
		            StreamReader streamReader = new StreamReader(filepathAutorunInf);
                    while ((stringInputLine = streamReader.ReadLine()) != null) 
                      {
                          if (stringInputLine.StartsWith("label="))
                              return stringInputLine.Substring(startIndex:6);
                      }
                    return "";
	            }
                else return "";
            }
            #region generic catch exception, display message box, and terminate
            catch (Exception exception)
            {
                System.Diagnostics.StackTrace trace = new System.Diagnostics.StackTrace(exception, true);
                MessageBox.Show(string.Format("{0} Exception:\n{1}\n{2}\n\n{3}\n\nMethod={4}   Line={5}   Column={6}",
                        trace.GetFrame(0).GetMethod().Module,
                        exception.Message,
                        exception.StackTrace,
                        exception.ToString(),
                        trace.GetFrame(0).GetMethod().Name,
                        trace.GetFrame(0).GetFileLineNumber(),
                        trace.GetFrame(0).GetFileColumnNumber()),
                    "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                Environment.Exit(1);
                return "";      // to keep compiler happy
            }
            #endregion
        }
