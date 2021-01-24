    [HttpPost("[action]")]
        public async Task<IActionResult> UploadFiles(IFormFile files)
        {
    
            string hresult = "done";
    
            string message = "uploaded Successfully";
    
            try
            {
                Stream stream = files.OpenReadStream();
    
                var binaryReader = new BinaryReader(stream);
    
                var fileContent = binaryReader.ReadBytes((int)files.Length);
                MemoryStream ms = new MemoryStream(fileContent);
    
                using (ExcelPackage package = new ExcelPackage(ms))
                {
                    StringBuilder sb = new StringBuilder();
                    ExcelWorksheet worksheet = package.Workbook.Worksheets[1];
                    int rowCount = worksheet.Dimension.Rows;
                    int ColCount = worksheet.Dimension.Columns;
                    bool bHeaderRow = true;
                    int tempCount = 0;
                    for (int row = 1; row <= rowCount; row++)
                    {
                        for (int col = 1; col <= ColCount; col++)
                        {
                            if (bHeaderRow)
                            {
                                sb.Append(worksheet.Cells[row, col].Value.ToString() + "\t");
                            }
                            else
                            {
                                sb.Append(worksheet.Cells[row, col].Value.ToString() + "\t");
                            }
    
                            var pertc = tempCount * 100 / rowCount;
                            tempCount++;
                            var progresult = new ObjectResult(pertc)
                            {
                                StatusCode = (int)HttpStatusCode.OK
                            };
                            Request.HttpContext.Response.Headers.Add("X-Total-Count", "Working");
                            return Ok(progresult);
    
    
                        }
                        sb.Append(Environment.NewLine);
                    }
    
                }
            }
            catch (Exception ex)
            {
                hresult = ex.Message;
    
    
            }
    
            var result = new ObjectResult(message)
            {
                StatusCode = (int)HttpStatusCode.OK
            };
            Request.HttpContext.Response.Headers.Add("X-Total-Count", hresult);
            return Ok(result);
    
    
        }
