    //Create empty OOB data list
            List<OOBList.OOBDetails> oob_data = new List<OOBList.OOBDetails>();
            string fileName = Server.MapPath("~/Uploads/OOB List/") + fname;
            using (var excelWorkbook = new XLWorkbook(fileName))
            {
                var nonEmptyDataRows = excelWorkbook.Worksheet(2).RowsUsed();
                foreach (var dataRow in nonEmptyDataRows)
                {
                    //for row number check
                    if (dataRow.RowNumber() >= 4 )
                    {
                        string siteno = dataRow.Cell(1).GetValue<string>();
                        string sitename = dataRow.Cell(2).GetValue<string>();
                        string description = dataRow.Cell(4).GetValue<string>();
                        string cabinoob = dataRow.Cell(5).GetValue<string>();
                        string toweroob = dataRow.Cell(6).GetValue<string>();
                        string manageoob = dataRow.Cell(7).GetValue<string>();
                        string resolutiondate = dataRow.Cell(8).GetValue<string>();
                        string resolutiondate_converted = resolutiondate.Substring(resolutiondate.Length - 9);
                        oob_data.Add(new OOBList.OOBDetails
                        {
                            SiteNo = siteno,
                            SiteName = sitename,
                            Description = description,
                            CabinOOB = cabinoob,
                            TowerOOB = toweroob,
                            ManageOOB = manageoob,
                            TargetResolutionDate = resolutiondate_converted
                        });
                        Debug.Write("Adding SiteNo: " + siteno + "\n");
                    }
                }
            }
