        [HttpPost]
        public ActionResult BulkUserUpload(HttpPostedFileBase uploadFile)
        {
            string			tempFileName		    = string.Empty;
            string          errorMessage            = string.Empty;
			if (uploadFile != null && uploadFile.ContentLength > 0)
            {
                //ExcelExtension contains array of excel extension types
				if ( Config.ExcelExtension.Any(p => p.Trim() == Path.GetExtension(uploadFile.FileName)) )
				{
					//save the uploaded excel file to temp location
					SaveExcelTemp(uploadFile, out tempFileName);
                    //validate the excel sheet
					if (ValidateExcel(tempFileName, out errorMessage))
					{
						//save the data
						SaveExcelDataToDatabase(tempFileName);
						//spreadsheet is valid, show success message or any logic here
					}
					else
					{
						//set error message to shown in front end
						ViewBag.ErrorMessage		= errorMessage;
					}
				}
				else
				{
					//excel sheet is not uploaded, show error message
				}                                
            }
			else
			{
				//file is not uploaded, show error message
			}
            return View();
        }
        private bool ValidateExcel(string tempFileName, out string errorMessage)
		{
			bool				result				= true;
            string              error               = string.Empty;
			string				filePath			= GetTempFilePath(tempFileName);
			FileInfo			fileInfo			= new FileInfo(filePath);
			ExcelPackage		excelPackage		= new ExcelPackage(fileInfo);
			ExcelWorksheet		worksheet			= excelPackage.Workbook.Worksheets.First();
			int					totalRows			= worksheet.Dimension == null ? -1 : worksheet.Dimension.End.Row; //worksheet total rows
			int					totalCols			= worksheet.Dimension == null ? -1 : worksheet.Dimension.End.Column; // total columns
            //check spread sheet has rows (empty spreadsheet uploaded)
            if (totalRows == -1)
            {
                result                              = false;
                error                               = "Empty spread sheet uploaded.";
            }
            //check rows are more than or equal 2 (spread sheet has only header row)
            else if (totalRows < 2)
            {
                result                              = false;
                error                               = "Spread sheet does not contain any data";
            }
            //check total columns equal to headers defined (less columns)
            else if (totalCols > 0 && totalCols != GetColumnHeaders().Count)
            {
                result                              = false;
                error                               = "Spread sheet column header value mismatch.";
            }
            if (result)
            {
                //validate header columns
                result                              &= ValidateColumns(worksheet, totalCols);
                if (result)
                {
                    //validate data rows, skip the header row (data rows start from 2)
                    result                          &= ValidateRows(worksheet, totalRows, totalCols);
                }
                if (!result)
                {
                    error                           = "There are some errors in the uploaded file. Please correct them and upload again.";
                }
            }
            errorMessage                            = error;
			worksheet.Cells[worksheet.Dimension.Address].AutoFitColumns();
			excelPackage.Save();
			return result;
		}
