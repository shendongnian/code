        private string RunMdb(string path, string functionToRun, bool visible)
        {
            string result;
            try
            {
                Directory.SetCurrentDirectory(newDir);
				// get the MS Access process, we need it later
                var before = Process.GetProcessesByName("MSACCESS");
                MsAccessApp = new Microsoft.Office.Interop.Access.Application { Visible = visible };
                var after = Process.GetProcessesByName("MSACCESS");
                var process = after.Single(p => !before.Select(p1 => p1.Id).Contains(p.Id));
                MsAccessProc = process;
                MsAccessApp.OpenCurrentDatabase(newDbPath, false);
                result = MsAccessApp.Run(functionToRun);
            }
            catch (Exception e)
            {
                result = $"MS Access Error: {e.Message}";
                log.Log("MS Access Error:", e);
            }
            finally
            {
                if (IsFunctionRunning)
                {
                    try
                    {
                        MsAccessApp.CloseCurrentDatabase();
                    }
                    catch
                    {
                        // ignored
                    }
                    try
                    {
                        MsAccessApp.Quit(Microsoft.Office.Interop.Access.AcQuitOption.acQuitSaveNone);
                    }
                    catch
                    {
                        // ignored
                    }
                }
            }
            MsAccessApp = null;
            MsAccessProc = null;
            IsFunctionRunning = false;
            return result;
        }
