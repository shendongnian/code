        protected void GetExcel_Click(object sender, EventArgs e)
        {            
            ManageTicketBS objManageTicket = new ManageTicketBS();
            DataTable DT = objManageTicket.GetAlldataByDate();   //this function will bring the data in DataTable format, you can use your function instate of that.  
            string DownloadFileName;
            string FolderPath;
            string FileName = "MyTemplate.xlsx";
            DownloadFileName = Path.GetFileNameWithoutExtension(FileName) + new Random().Next(10000, 99999) + Path.GetExtension(FileName);
            FolderPath = ".\\" + DownloadFileName;
            GetParents(Server.MapPath("~/Document/" + FileName), Server.MapPath("~/Document/" + DownloadFileName), DT);
            string path = Server.MapPath("~/Document/" + FolderPath);
            FileInfo file = new FileInfo(path);
            if (file.Exists)
            {
                try
                {
                    HttpResponse response = HttpContext.Current.Response;
                    response.Clear();
                    response.ClearContent();
                    response.ClearHeaders();
                    response.Buffer = true;
                    response.ContentType = MimeType(Path.GetExtension(FolderPath));
                    response.AddHeader("Content-Disposition", "attachment;filename=" + DownloadFileName);
                    byte[] data = File.ReadAllBytes(path);
                    response.BinaryWrite(data);
                    HttpContext.Current.ApplicationInstance.CompleteRequest();
                    response.End();
                }
                catch (Exception ex)
                {
                    ex.ToString();
                }
                finally
                {
                    DeleteOrganisationtoSupplierTemplate(path);
                }
            }
        }
        public string GetParents(string FilePath, string TempFilePath, DataTable DTTBL)
        {
            File.Copy(Path.Combine(FilePath), Path.Combine(TempFilePath), true);
            FileInfo file = new FileInfo(TempFilePath);
            try
            {
                DatatableToExcel(DTTBL, TempFilePath, 0);
               
                return TempFilePath;
            }
            
            catch (Exception ex)
            {                
                return "";
            }
            
        }
        public static string MimeType(string Extension)
        {
            string mime = "application/octetstream";
            if (string.IsNullOrEmpty(Extension))
                return mime;
            string ext = Extension.ToLower();
            Microsoft.Win32.RegistryKey rk = Microsoft.Win32.Registry.ClassesRoot.OpenSubKey(ext);
            if (rk != null && rk.GetValue("Content Type") != null)
                mime = rk.GetValue("Content Type").ToString();
            return mime;
        }
        static bool DeleteOrganisationtoSupplierTemplate(string filePath)
        {
            try
            {                
                File.Delete(filePath);
                return true;
            }
            catch (IOException)
            {               
                return false;
            }
        }
        public void DatatableToExcel(DataTable dtable, string pFilePath, int excelSheetIndex=1)
        {
            try
            {
                if (dtable != null && dtable.Rows.Count > 0)
                {
                    IWorkbook workbook = null;
                    ISheet worksheet = null;
                    using (FileStream stream = new FileStream(pFilePath, FileMode.Open, FileAccess.ReadWrite))
                    {
                         
                        workbook = WorkbookFactory.Create(stream);
                        worksheet = workbook.GetSheetAt(excelSheetIndex);
                        int iRow = 1;
                        
                        foreach (DataRow row in dtable.Rows)
                        {
                            IRow file = worksheet.CreateRow(iRow);
                            int iCol = 0;
                            foreach (DataColumn column in dtable.Columns)
                            {
                                ICell cell = null;
                                object cellValue = row[iCol];
                                switch (column.DataType.ToString())
                                {
                                    case "System.Boolean":
                                        if (cellValue != DBNull.Value)
                                        {
                                            cell = file.CreateCell(iCol, CellType.Boolean);
                                            if (Convert.ToBoolean(cellValue)) { cell.SetCellFormula("TRUE()"); }
                                            else { cell.SetCellFormula("FALSE()"); }
                                            //cell.CellStyle = _boolCellStyle;
                                        }
                                        break;
                                    case "System.String":
                                        if (cellValue != DBNull.Value)
                                        {
                                            cell = file.CreateCell(iCol, CellType.String);
                                            cell.SetCellValue(Convert.ToString(cellValue));
                                        }
                                        break;
                                    case "System.Int32":
                                        if (cellValue != DBNull.Value)
                                        {
                                            cell = file.CreateCell(iCol, CellType.Numeric);
                                            cell.SetCellValue(Convert.ToInt32(cellValue));
                                            //cell.CellStyle = _intCellStyle;
                                        }
                                        break;
                                    case "System.Int64":
                                        if (cellValue != DBNull.Value)
                                        {
                                            cell = file.CreateCell(iCol, CellType.Numeric);
                                            cell.SetCellValue(Convert.ToInt64(cellValue));
                                            //cell.CellStyle = _intCellStyle;
                                        }
                                        break;
                                    case "System.Decimal":
                                        if (cellValue != DBNull.Value)
                                        {
                                            cell = file.CreateCell(iCol, CellType.Numeric);
                                            cell.SetCellValue(Convert.ToDouble(cellValue));
                                            //cell.CellStyle = _doubleCellStyle;
                                        }
                                        break;
                                    case "System.Double":
                                        if (cellValue != DBNull.Value)
                                        {
                                            cell = file.CreateCell(iCol, CellType.Numeric);
                                            cell.SetCellValue(Convert.ToDouble(cellValue));
                                            //cell.CellStyle = _doubleCellStyle;
                                        }
                                        break;
                                    case "System.DateTime":
                                        if (cellValue != DBNull.Value)
                                        {
                                            cell = file.CreateCell(iCol, CellType.String);
                                            DateTime dateTime = Convert.ToDateTime(cellValue);
                                            cell.SetCellValue(dateTime.ToString("dd/MM/yyyy"));
                                            DateTime cDate = Convert.ToDateTime(cellValue);
                                            if (cDate != null && cDate.Hour > 0)
                                            {
                                                //cell.CellStyle = _dateTimeCellStyle; 
                                            }
                                            else
                                            {
                                                // cell.CellStyle = _dateCellStyle; 
                                            }
                                        }
                                        break;
                                    default:
                                        break;
                                }
                                iCol++;
                            }
                            iRow++;
                        }
                        using (var WritetoExcelfile = new FileStream(pFilePath, FileMode.Create, FileAccess.ReadWrite))
                        {
                            workbook.Write(WritetoExcelfile);
                            WritetoExcelfile.Close();
                            //workbook.Write(stream);
                            stream.Close();
                        }
                    }
                }
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }
