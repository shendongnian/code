              protected void Page_Load(object sender, EventArgs e)
                 {
                   if (!Page.IsPostBack)
                     {
                     Excel.Application appExl;
                     Excel.Workbook workbook;
                     Excel.Worksheet NwSheet;
                     Excel.Range ShtRange;
                     appExl = new Excel.Application();
                    / /Opening Excel file
                     workbook = appExl.Workbooks.Open(Server.MapPath("firstexcel.xlsx"));
                     NwSheet = (Excel.Worksheet)workbook.Sheets.get_Item(1);
                     int Cnum = 0;
                     int Rnum = 0;
                      ShtRange = NwSheet.UsedRange; 
                    //Reading Excel file.
                    //Creating datatable to read the containt of the Sheet in File.
                      DataTable dt = new DataTable();
                       dt.Columns.Add("EMP NO");
                      dt.Columns.Add("NAME");
                      dt.Columns.Add("AGE");
                      dt.Columns.Add("PHN NO");
                      dt.Columns.Add("EMAIL");
                     for (Rnum = 2; Rnum <= ShtRange.Rows.Count; Rnum++)
                         {
                           DataRow dr = dt.NewRow();
                  //Reading  Each Column value From sheet to datatable
             
                  for (Cnum = 1; Cnum <= ShtRange.Columns.Count; Cnum++)
                        {
                         dr[Cnum - 1] = (ShtRange.Cells[Rnum, Cnum] as Excel.Range).Value2.ToString();
                        }
                 // adding Row into DataTable
                  dt.Rows.Add(dr); 
                  dt.AcceptChanges();
                       }
                  workbook.Close(true);
                 appExl.Quit();
                //DataSource to GrigView
               gvOne.DataSource = dt;
               gvOne.DataBind();
                 }
            }
       
