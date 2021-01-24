    private ExcelPackage CreateDoc(string title, string subject, string keyword)
        {
            var p = new ExcelPackage();
            p.Workbook.Properties.Title = title;
            p.Workbook.Properties.Author = "Application Name";
            p.Workbook.Properties.Subject = subject;
            p.Workbook.Properties.Keywords = keyword;
            return p;
        }
    public ExcelPackage getApplicantsStatistics()
        {
            ExcelPackage p = CreateDoc("Applicant Statistics", "Applicant statistics", "All Applicants");
            var worksheet = p.Workbook.Worksheets.Add("Applicant Statistics");
            //Add Report Header
            worksheet.Cells[1, 1].Value = "Applicant Statistics";
            worksheet.Cells[1, 1, 1, 3].Merge = true;
          //Get the data you want to send to the excel file
            var appProg = _unitOfWork.ApplicantsProgram
                            .AllIncluding(pr => pr.Program1)
                            .GroupBy(ap => ap.Program1.Name)
                            .Select(ap => new { programName = ap.Key, TotalNum = ap.Count() })
                            .ToList();
            //First add the headers
            worksheet.Cells[2, 1].Value = "SR No";
            worksheet.Cells[2, 2].Value = "Program";
            worksheet.Cells[2, 3].Value = "No. of Applicants";
            //Add values
            var numberformat = "#,##0";
            var dataCellStyleName = "TableNumber";
            var numStyle = p.Workbook.Styles.CreateNamedStyle(dataCellStyleName);
            numStyle.Style.Numberformat.Format = numberformat;
            
            for (int i = 0; i < appProg.Count; i++)
            {
                worksheet.Cells[i + 3, 1].Value = i + 1;
                worksheet.Cells[i + 3, 2].Value = appProg[i].programName;
                worksheet.Cells[i + 3, 3].Value = appProg[i].TotalNum;
            }
            // Add to table / Add summary row
            var rowEnd = appProg.Count + 2;
            var tbl = worksheet.Tables.Add(new ExcelAddressBase(fromRow: 2, fromCol: 1, toRow: rowEnd, toColumn: 3), "Applicants");
            tbl.ShowHeader = true;
            tbl.TableStyle = TableStyles.Dark9;
            tbl.ShowTotal = true;
            tbl.Columns[2].DataCellStyleName = dataCellStyleName;
            tbl.Columns[2].TotalsRowFunction = RowFunctions.Sum;
            worksheet.Cells[rowEnd, 3].Style.Numberformat.Format = numberformat;
            // AutoFitColumns
            worksheet.Cells[2, 1, rowEnd, 3].AutoFitColumns();
            return p;
        }
