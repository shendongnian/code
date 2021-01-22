     private static void StatusChecking()
            {
                IntPtr iActiveForm = IntPtr.Zero, iCurrentACtiveApp = IntPtr.Zero;
                Int32 iMyProcID = Process.GetCurrentProcess().Id, iCurrentProcID = 0;
                IntPtr iTmp = (IntPtr)1;
                while (bIsRunning)
                {
                    try
                    {
                        Thread.Sleep(45);
                        if (Form.ActiveForm != null)
                        {
                            iActiveForm = Form.ActiveForm.Handle;
                        }
                        iTmp = GetForegroundWindow();
                        if (iTmp == IntPtr.Zero) continue;
                        GetWindowThreadProcessId(iTmp, ref iCurrentProcID);
                        if (iCurrentProcID == 0)
                        {
                            iCurrentProcID = 1;
                            continue;
                        }
                        if (iCurrentProcID != iMyProcID)
                        {
                            SystemParametersInfo(SPI_GETFOREGROUNDLOCKTIMEOUT, 0, IntPtr.Zero, 0);
                            SystemParametersInfo(SPI_SETFOREGROUNDLOCKTIMEOUT, 0, IntPtr.Zero, SPIF_SENDCHANGE);
                            BringWindowToTop(iActiveForm);
                            SetForegroundWindow(iActiveForm);
                        }
                        else iActiveForm = iTmp;
                    }
                    catch (Exception ex)
                    {
                        Definitions.UnhandledExceptionHandler(ex, 103106);
                    }
                }
            }
           
