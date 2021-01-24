                DataTable resultsDT = new DataTable();
                resultsDT.Columns.Add("LoanNUmber");
                resultsDT.Columns.Add("Error");
                XDocument X = XDocument.Load(pathStatusRequestResult);
                var status = X.Element("CWL_DATA").Element("CWL_RESPONSE");
                var statusData = status.Element("RESPONSE_DATA").Elements("CDR_STATUS");
                foreach(var item in statusData)
                {
                    // returns the value of teh UploadStatus
                    bool uploadStatus = (item.Attribute("UploadStatus").Value) == "Failed" ? false : true;
                    string loanNumber = item.Attribute("ClientLoanNumber").Value;
                    if (uploadStatus == false)
                    {
                        var errorData = item.Elements("CDR_ERROR");
                        foreach(var e in errorData)
                        {
                            string error = e.Attribute("Message").Value;
                            resultsDT.Rows.Add(loanNumber, error);
                        }
                    }
                }
