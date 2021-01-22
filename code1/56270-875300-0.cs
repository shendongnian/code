    var columns = new List<IColumn<EmployeeInfoDTO>>
                      {
                          new Column<EmployeeInfoDTO>("Full name", e => string.Format("{0} {1}", e.FirstName, e.Name)),
                          new Column<EmployeeInfoDTO>("Examination date", e => e.ExaminationDate.HasValue? string.Format("{0} days ago", currentDate.Subtract(e.ExaminationDate.Value).Days) : "Unknown")
                      };
    
    var employeeGrid = new TrustGrid<EmployeeInfoDTO> { Columns = columns, Elements = GetEmployees(currentPageIndex)};
    
    ViewData["employeeGrid"] = employeeGrid;
