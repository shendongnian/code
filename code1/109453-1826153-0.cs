            catch (Exception theException)
            {
                theException.ToString();
            }
            #region COM Object Cleanup
            finally
            {
                // Cleanup
                GC.Collect();
                GC.WaitForPendingFinalizers();
                System.Runtime.InteropServices.Marshal.FinalReleaseComObject(oRng);
                //System.Runtime.InteropServices.Marshal.FinalReleaseComObject(sumSheet);
                //System.Runtime.InteropServices.Marshal.FinalReleaseComObject(oSheet);
                //oWB.Close(null, null, null);
                System.Runtime.InteropServices.Marshal.FinalReleaseComObject(oWB);
                oXL.Quit();
                System.Runtime.InteropServices.Marshal.FinalReleaseComObject(oXL);
            }
            #endregion
