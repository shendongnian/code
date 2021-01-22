                    CRAXDRT.Report report2 = new CRAXDRT.Report();
                    CRAXDRT.Application app2 = new CRAXDRT.Application();
                    report2 = app2.OpenReport("YourReportName.rpt", OpenReportMethod.OpenReportByDefault);
                    for (int i = 1; i < report2.Sections.Count + 1; i++)
                    {
                        for (int j = 1; j < report2.Sections[i].ReportObjects.Count + 1; j++)
                        {
                            try
                            {
                                CRAXDRT.OleObject to2 = (CRAXDRT.OleObject)report2.Sections[i].ReportObjects[j];
                                CRAXDRT.OleObject to3 = report2.Sections[i].AddPictureObject("NewOleName.bmp", to2.Left, to2.Top);
                                to3.Height = to2.Height;
                                to3.Width = to2.Width;
                                report2.Sections[i].DeleteObject(to2);
                            }
                            catch (Exception) { }
                        }
                    }
