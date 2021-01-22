        private ArrayList collOutput = null;
        string sSheetName = String.Empty;
        string[] strValidColumn;
        int validRowCnt = 0;
        string sColumnPositions = String.Empty;
        OleDbCommand ExcelCommand;
        OleDbDataAdapter ExcelAdapter;
        OleDbConnection ExcelConnection = null;
        DataSet dsSheet = null;
        string path = string.Empty;
        string identifier = string.Empty;
        public ExcelParser()
        {
            collOutput = new ArrayList();
        }      
  
        public void Extract()
        {
            bool headermatch = false;
            string strCusip = string.Empty, strOrig = string.Empty, strPrice = string.Empty, strData = string.Empty;
            string strCusipPos = string.Empty, strPricePos = string.Empty, strOrigPos = string.Empty;
            string strColumnHeader = String.Empty;
            int reqColcount = 0;
            string[] strTemp;
            bool bTemp = false;
            bool validRow = false;
            DataTable schemaTable = GetSchemaTable();
            validRowCnt = 0;
            foreach (DataRow dr in schemaTable.Rows)
            {
                if (dsSheet != null)
                {
                    dsSheet.Reset();
                    dsSheet = null;
                }
                strCusipPos = string.Empty;
                strOrigPos = string.Empty;
                strPricePos = string.Empty;
                if (isValidSheet(dr))
                {
                    sColumnPositions = string.Empty;
                    validRowCnt = 0;
                    foreach (DataRow dataRow in dsSheet.Tables[0].Rows)
                    {
                        sColumnPositions = string.Empty;
                        if (headermatch == false)
                        {
                            sColumnPositions = string.Empty;
                            foreach (DataColumn column in dsSheet.Tables[0].Columns)
                            {
                                strColumnHeader = dataRow[column.ColumnName].ToString().ToUpper().Trim();
                                strColumnHeader = strColumnHeader.ToUpper();
                                if (strColumnHeader == ExcelHeaderValues.ORIG.ToUpper() || strColumnHeader == ExcelHeaderValues.CUSIP.ToUpper() || strColumnHeader == ExcelHeaderValues.PRICE.ToUpper())
                                {
                                    bTemp = true;
                                    validRow = true;
                                    reqColcount = ExcelHeaderValues.COLUMNCOUNT;
                                }
                                if (bTemp)
                                {
                                    bTemp = false;
                                    sColumnPositions += column.ColumnName + "^" + strColumnHeader + ";";
                                }
                            }
                            strValidColumn = sColumnPositions.Trim().Split(';');
                            if (validRow == true && reqColcount == strValidColumn.Length - 1)
                            {
                                headermatch = true;
                                break;
                            }
                            validRowCnt++;
                        }
                    }
                    if (headermatch == true)
                    {
                        try
                        {
                            if (dsSheet.Tables[0].Rows.Count > 0)
                            {
                                if (strValidColumn.Length > 0)
                                {
                                    for (int i = 0; i < strValidColumn.Length - 1; i++)
                                    {
                                        if (strValidColumn[i].ToUpper().Contains("CUSIP"))
                                        {
                                            strTemp = strValidColumn[i].ToString().Split('^');
                                            strCusipPos = strTemp[0].ToString();
                                            strTemp = null;
                                        }
                                        if (strValidColumn[i].ToUpper().Contains("PRICE"))
                                        {
                                            strTemp = strValidColumn[i].ToString().Split('^');
                                            strPricePos = strTemp[0].ToString();
                                            strTemp = null;
                                        }
                                        
                                        if (strValidColumn[i].ToUpper().Contains("ORIG"))
                                        {
                                            strTemp = strValidColumn[i].ToString().Split('^');
                                            strOrigPos = strTemp[0].ToString();
                                            strTemp = null;
                                        }
                                    }
                                }
                                for (int iData = validRowCnt; iData < dsSheet.Tables[0].Rows.Count; iData++)
                                {
                                    if (strCusipPos.Trim() != "")
                                        strCusip = dsSheet.Tables[0].Rows[iData][strCusipPos].ToString().Trim();
                                    if (strOrigPos.Trim() != "")
                                        strOrig = dsSheet.Tables[0].Rows[iData][strOrigPos].ToString().Trim();
                                    if (strPricePos.Trim() != "")
                                        strPrice = dsSheet.Tables[0].Rows[iData][strPricePos].ToString().Trim().ToUpper();
                                    strData = "";
                                    if (strCusip.Length == 9 && strCusip != "" && strPrice != "" && strOrig != "" && !strPrice.ToUpper().Contains("SOLD"))
                                        strData = strCusip + "|" + Convert.ToDouble(strOrig) * 1000000 + "|" + strPrice + "|||||";
                                    if (strData != null && strData != "")
                                        collOutput.Add(strData);
                                    strCusip = string.Empty;
                                    strOrig = string.Empty;
                                    strPrice = string.Empty;
                                    strData = string.Empty;
                                }
                            }
                        }
                        catch (Exception ex)
                        {
                            throw ex;
                        }
                    }
                    headermatch = false;
                    sColumnPositions = string.Empty;
                    strColumnHeader = string.Empty;
                }
            }
        }
       
        private bool isValidSheet(DataRow dr)
        {
            bool isValidSheet = false;
            sSheetName = dr[2].ToString().ToUpper();
                        
            if (!(sSheetName.Contains("$_")) && !(sSheetName.Contains("$'_")) && (!sSheetName.Contains("Print_Titles".ToUpper())) && (dr[3].ToString() == "TABLE" && ((!sSheetName.Contains("Print_Area".ToUpper())))) && !(sSheetName.ToUpper() == "DLOFFERLOOKUP"))
            {
                if (sSheetName.Trim().ToUpper() != "Disclaimer$".ToUpper() && sSheetName.Trim().ToUpper() != "Summary$".ToUpper() && sSheetName.Trim().ToUpper() != "FORMULAS$" )
                {
                    string sQry = string.Empty;        
                    sQry = "SELECT * FROM [" + sSheetName + "]";
                    ExcelCommand = new OleDbCommand(sQry, ExcelConnection);
                    dsSheet = new DataSet();
                    ExcelAdapter = new OleDbDataAdapter(ExcelCommand);
                    isValidSheet = false;
                    try
                    {
                         ExcelAdapter.Fill(dsSheet, sSheetName);
                        isValidSheet = true;
                    }
                    catch (Exception ex)
                    {
                        isValidSheet = false;
                        throw new Exception(ex.Message.ToString());
                    }
                    finally
                    {
                        ExcelAdapter = null;
                        ExcelCommand = null;
                    }
                }
            }           
            return isValidSheet;
        }
        
       
        private DataTable GetSchemaTable()
        {
            DataTable dt = null;
            string connectionString = String.Empty;
            connectionString = GetConnectionString();
            ExcelConnection = new OleDbConnection(connectionString);
            try
            {
                ExcelConnection.Open();
                dt = ExcelConnection.GetOleDbSchemaTable(OleDbSchemaGuid.Tables, new object[] { null, null, null, "TABLE" });
            }
            catch (Exception ex)
            {
                throw ex;
            }
            return dt;
        }
        
       
        private string GetConnectionString()
        {
            string connStr = String.Empty;
            try
            {
                
                if (path.ToLower().Contains(".xlsx"))
                {
                    connStr = "Provider=Microsoft.ACE.OLEDB.12.0;" + "Data Source='" + path + "';" + "Extended Properties='Excel 12.0;HDR=No;IMEX=1;'";
                }
                else if (path.ToLower().Contains(".xlsm"))
                {
                    connStr = "Provider=Microsoft.ACE.OLEDB.12.0;" + "Data Source='" + path + "';" + "Extended Properties='Excel 12.0 Macro;HDR=No;IMEX=1;'";
                }
                else if (path.ToLower().Contains(".xls"))
                {
