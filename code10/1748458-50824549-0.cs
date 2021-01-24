    using Excel = Microsoft.Office.Interop.Excel;
    private void button9_Click(object sender, EventArgs e)
    {
        Excel.Application oXL;
        Excel.Workbooks oWBs;
        Excel.Workbook oWB;
        Excel.Worksheets oSheets;
        Excel.Worksheet oSheet;
        Excel.Worksheet TrackingSheet;
        Excel.Range aRange;
        Excel.Range oSheetCells;
        Excel.Range oSheetColumns;
        try
        {
            //Start Excel and get Application object.
            oXL = new Microsoft.Office.Interop.Excel.Application();
            if (track == false)
            {
                //oXL.Visible = true;
                //Get a new workbook.
                oWBs = oXL.Workbooks;
                oWB = oWBs.Add(Missing.Value);
                //Unique ID Tab
                TrackingSheet = (Excel.Worksheet)oWB.ActiveSheet;
                TrackingSheet.Name = "UniqueID Tracking List";
                for (int i = 0; i < listBox1.Items.Count; i++)
                {
                    TrackingSheet.Cells[i+1, 1] = listBox1.Items[i];
                    UIDList.add(listBox1.Items[i]);
                }
                TrackingSheet = oWBs.Add();
                oSheet = (Excel.Worksheet)oWB.ActiveSheet;
                oSheet.Name = "SlackTrend";
                //Add table headers going cell by cell.
                oSheet.Cells[1, 1] = "Status Date";
                oSheet.Cells[2, 1] = "Unique ID";
                oSheet.Cells[2, 2] = "Task Name";
                oSheet.Cells[2, 3] = "% Complete";
                oSheet.Cells[2, 4] = "Finish Date";
                oSheet.Cells[2, 5] = "Baseline Finish";
                //Creates the monthly bins (User entry for range) - goes from current month onward if creating
                int monthS = comboBox2.SelectedIndex + 1;  
                int yearS = comboBox3.SelectedIndex + 2000;
                Date status = CurrentFile.ProjectProperties.StatusDate;
                int yearstatus = status.getYear();
                int monthstatus = status.getMonth();
                int daystatus = status.getDate();
                System.String statusDate = (monthstatus + 1) + "/" + daystatus + "/" + (yearstatus + 1900);
                System.String statuskeyCode = (monthstatus + 1) + "-" + (yearstatus + 1900);
                System.String monthYear = monthS + "-" + yearS;
                int slackLocation = 6; //Double Check this logic
                for (int i = 0; i < 15; i++)
                {
                    oSheet.Cells[2, 6 + i] = monthYear;
                    monthS++;
                    if (monthS > 12)
                    {
                        monthS = 1;
                        yearS++;
                    }
                    if (monthYear.Equals(statuskeyCode))
                    {
                        oSheet.Cells[1, 6 + i] = statusDate;
                        slackLocation = 6 + i;
                    }
                    monthYear = monthS + "-" + yearS;
                }
                for (int i = 0; i < UIDList.size(); i++)
                {
                    net.sf.mpxj.Task c = CurrentFile.GetTaskByUniqueID(java.lang.Integer.valueOf((Int32.Parse(UIDList.get(i).ToString()))));
                    Duration d = c.Duration;
                    System.String name = c.Name;
                    //Date Conversion
                    Date d1 = c.Finish;
                    Number percent = c.PercentageComplete;
                    Date Baseline = c.BaselineFinish;
                    int year = d1.getYear();
                    int month = d1.getMonth();
                    int day = d1.getDate();
                    int yearb = Baseline.getYear();
                    int monthb = Baseline.getMonth();
                    int dayb = Baseline.getDate();
                    double slack = c.TotalSlack.Duration;
                    System.String newDate = month + 1 + "/" + day + "/" + (year + 1900);
                    System.String newBaselineDate = month + 1 + "/" + day + "/" + (year + 1900);
                    oSheet.Cells[i + 3, 1] = UIDList.get(i);
                    oSheet.Cells[i + 3, 2] = name;
                    oSheet.Cells[i + 3, 3] = percent;
                    oSheet.Cells[i + 3, 4] = newDate;
                    oSheet.Cells[i + 3, 5] = newBaselineDate;
                    oSheet.Cells[i + 3, slackLocation] = slack;
                    oSheet.Cells[1, slackLocation] = statusDate;
                }
                //Expands columns
                aRange = oSheet.get_Range("A1", "Z1");
                aRange = aRange.EntireColumn;
                aRange.AutoFit();
                oWB.SaveAs(name4);
                //System.Windows.Forms.Application.Exit();
                //oWB.Close(true, name4, null);
                //oXL.Quit();
                //Make sure Excel is visible and give the user control
                //of Microsoft Excel's lifetime.
                oXL.Visible = true;
                oXL.UserControl = true;
            }
            else
            {
                //else statement for existing tracking file
                oWBs = oXL.Workbooks;
                oWB = oWBs.Open(name3,0,false);
                //Selects active sheet
                oSheets = oWB.Worksheets;
                oSheet = (Excel.Worksheet)oSheets.get_Item(2);
                oSheet.Activate();
                aRange = oSheet.UsedRange;
                aRange = aRange.Rows;
                oSheetCells = oSheet.Cells;
                //Collecting UIDs to trend (Assuming no added/deleted)
                ArrayList UIDList = new ArrayList();
                /*
                for (int i = 1; i < aRange.Count + 1; i++)
                {
                    object value = oSheetCells[i, 1].Value;
                    UIDList.add(value.ToString());
                }
                */
                for (int i = 0; i < listBox1.Items.Count; i++)
                {
                    oSheetCells[i + 1, 1] = listBox1.Items[i];
                    UIDList.add(listBox1.Items[i]);
                }
                //Trending new data points for existing UIDs
                oSheet = (Excel.Worksheet)oSheets.get_Item(1);
                oSheet.Activate();
                //user-inputted status month bin
                int monthS = comboBox2.SelectedIndex+1;
                int yearS = comboBox3.SelectedIndex+2000;
                Date status = CurrentFile.ProjectProperties.StatusDate;
                int yearstatus = status.getYear();
                int monthstatus = status.getMonth();
                int daystatus = status.getDate();
                System.String statusDate = (monthstatus + 1) + "/" + daystatus + "/" + (yearstatus + 1900);
                System.String statuskeyCode = (monthstatus + 1) + "-" + (yearstatus + 1900);
                System.String monthYear = monthS + "/1/" + yearS + " 12:00:00 AM";
                //Create List for Tracking File Comparison
                ArrayList existingList = new ArrayList();
                //Making List to check if UID already exists
                for(int i = 3; i < aRange.Count+1; i++)
                {
                    object value = oSheetCells[i, 1].Value;
                    existingList.add(value.ToString());
                }
                // loop through UID List
                for (int j = 0; j < UIDList.size(); j++)
                {
                    if (existingList.contains(UIDList.get(j).ToString()) == false)
                    {
                        System.String UID = (System.String)UIDList.get(j);
                        net.sf.mpxj.Task c = CurrentFile.GetTaskByUniqueID(java.lang.Integer.valueOf(UID));
                        Duration d = c.Duration;
                        System.String name = c.Name;
                        //Date Conversion
                        Date d1 = c.Finish;
                        Number percent = c.PercentageComplete;
                        Date Baseline = c.BaselineFinish;
                        int year = d1.getYear();
                        int month = d1.getMonth();
                        int day = d1.getDate();
                        int yearb = Baseline.getYear();
                        int monthb = Baseline.getMonth();
                        int dayb = Baseline.getDate();
                        double slack = c.TotalSlack.Duration;
                        System.String newDate = month + 1 + "/" + day + "/" + (year + 1900);
                        System.String newBaselineDate = month + 1 + "/" + day + "/" + (year + 1900);
                        //updating existing data from latest IMS
                        oSheetCells[aRange.Count + 1, 1] = UID;
                        oSheetCells[aRange.Count, 2] = name;
                        oSheetCells[aRange.Count, 3] = percent;
                        oSheetCells[aRange.Count, 4] = newDate;
                        oSheetCells[aRange.Count, 5] = newBaselineDate;
                        oSheetColumns = oSheet.UsedRange;
                        oSheetColumns = oSheetColumns.Columns;
                        for (int z = 0; z < oSheetColumns.Count - 6; z++)
                        {
                            object value = oSheetCells[2, 6 + z].Value;
                            if (monthYear.Equals(value.ToString()))
                            {
                                oSheetCells[aRange.Count, 6 + z] = slack;
                                oSheetCells[1, 6 + z] = statusDate;
                            }
                        }
                    }
                    //loop through trend sheet list
                    else
                    {
                        for (int k = 3; k < aRange.Count + 1; k++)
                        {
                            //check to see if list UIDs match
                            object value = oSheetCells[k, 1].Value;
                            if (UIDList.get(j).ToString().Equals(value.ToString()))
                            {
                                // Collect latest task data -> CORRECT THIS COMPARE
                                System.String UID = (System.String)UIDList.get(j);
                                net.sf.mpxj.Task c = CurrentFile.GetTaskByUniqueID(java.lang.Integer.valueOf(UID));
                                Duration d = c.Duration;
                                System.String name = c.Name;
                                //Date Conversion
                                Date d1 = c.Finish;
                                Number percent = c.PercentageComplete;
                                Date Baseline = c.BaselineFinish;
                                int year = d1.getYear();
                                int month = d1.getMonth();
                                int day = d1.getDate();
                                int yearb = Baseline.getYear();
                                int monthb = Baseline.getMonth();
                                int dayb = Baseline.getDate();
                                double slack = c.TotalSlack.Duration;
                                System.String newDate = month + 1 + "/" + day + "/" + (year + 1900);
                                System.String newBaselineDate = month + 1 + "/" + day + "/" + (year + 1900);
                                //updating existing data from latest IMS
                                oSheetCells[k, 2] = name;
                                oSheetCells[k, 3] = percent;
                                oSheetCells[k, 4] = newDate;
                                oSheetCells[k, 5] = newBaselineDate;
                                oSheetColumns = oSheet.UsedRange;
                                oSheetColumns = oSheetColumns.Columns;
                                for (int z = 0; z < oSheetColumns.Count - 6; z++)
                                {
                                    object value = oSheetCells[2, 6 + z].Value;
                                    if (monthYear.Equals(value.ToString()))
                                    {
                                        oSheetCells[k, 6 + z] = slack;
                                        oSheetCells[1, 6 + z] = statusDate;
                                    }
                                }
                            }
                        }
                    }
                }
                aRange = oSheet.get_Range("A1", "Z1");
                aRange = aRange.EntireColumn;
                aRange.AutoFit();
                //System.Windows.Forms.Application.Exit();
                oWB.SaveAs("C:\\Users\\acdavis1\\Desktop\\temp.xlsx");
                //xlWorkBook.SaveAs(name3);
                //File.Delete("C:\\Users\\acdavis1\\Desktop\\temp.xlsx");
                //xlWorkBook.Save(); // cant open read only
                oWB.Close(0);
                File.Delete(name3);
                oXL.Visible = true;
                oXL.UserControl = true;
                
            }
        }
        catch (System.Exception theException)
        {
            System.String errorMessage;
            errorMessage = "Error: ";
            errorMessage = System.String.Concat(errorMessage, theException.Message);
            errorMessage = System.String.Concat(errorMessage, " Line: ");
            errorMessage = System.String.Concat(errorMessage, theException.Source);
            MessageBox.Show(errorMessage, "Error");
        }
        finally
        {
            if (oXL != null) oXL.Quit();
            /* release the newest first */
            ReleaseCOM(oSheetColumns);
            ReleaseCOM(oSheetCells);
            ReleaseCOM(aRange);
            ReleaseCOM(TrackingSheet);
            ReleaseCOM(oSheet);
            ReleaseCOM(oSheets);
            ReleaseCOM(oWB);
            ReleaseCOM(oWBs);
            ReleaseCOM(oXL);
            System.Windows.Forms.Application.Exit();
        }
    }
    private void ReleaseCOM(object com)
    {
        try
        {
            System.Runtime.InteropServices.Marshal.ReleaseComObject(com);
            com = null;
        }
        catch
        {
            com = null;
        }
        finally
        {
            GC.Collect();
        }
    }
