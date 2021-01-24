    //Create datatable
     DataTable dt = new DataTable();
    
    //put Your columns Name
    dt.Columns.Add("ID", typeof(int));
    dt.Columns.Add("Name", typeof(string));
    dt.Columns.Add("Date", typeof(string));
    dt.Columns.Add("Total Records", typeof(string));
    
    //Your Query Code
     SQLiteConnection conn = new SQLiteConnection("Data Source=" + folderPath + "\\" + databaseName);
                            InitializeComponent();
                            s = MyProperty.ToString();
                            conn.Open();
                            SQLiteCommand command = new SQLiteCommand("SELECT id,nameSearch,dt,totalRecords FROM ACCESSDETAILS Where id=" + s + " AND numberSearch IS NULL AND dt BETWEEN '" + datepicker + "' AND '" +  datepicker1+ "'", conn);
                            SQLiteDataAdapter da = new SQLiteDataAdapter(command);
                             ds = new DataSet();
                        	 da.Fill(ds);
    
    #Fill Dataset values in Datatable rows   
    for (int i = 0; i < ds.Tables[0].Rows.Count; i++)
                        {
                            DataRow dr = dt.NewRow();
                            dr[0] =Convert.ToInt32( ds.Tables[0].Rows[i]["id"]);
                            dr[1] = ds.Tables[0].Rows[i]["namesearch"].ToString() + " " + ds.Tables[0].Rows[i]["lastname"].ToString(); 
                            dr[2] = ds.Tables[0].Rows[i]["dt"].ToString();
                            dr[3] = ds.Tables[0].Rows[i]["totalRecords"].ToString();
                            dt.Rows.Add(dr);
                        }                     
                            conn.Close() ;
    
    #For Print Datatable
    
                PrintDialog printDialog = new PrintDialog();
                if (printDialog.ShowDialog() == true)
                {
                    FlowDocument fd = new FlowDocument();
                   
                    Table table = new Table();
                    TableRowGroup tableRowGroup = new TableRowGroup();
                    TableRow r = new TableRow();
                    fd.PageWidth = printDialog.PrintableAreaWidth;
                    fd.PageHeight = printDialog.PrintableAreaHeight;
                    fd.BringIntoView();
    
                    fd.TextAlignment = TextAlignment.Center;
                    fd.ColumnWidth = 500;
                    table.CellSpacing = 0;
                    for (int j = 0; j < dt.Columns.Count; j++)
                    {
                        r.Cells.Add(new TableCell(new System.Windows.Documents.Paragraph(new Run(dt.Columns[j].ToString()))));
                        r.Cells[j].ColumnSpan = 4;
                        r.Cells[j].Padding = new Thickness(4);
                        r.Cells[j].BorderBrush = Brushes.Black;
                        r.Cells[j].FontWeight = FontWeights.Bold;
                        r.Cells[j].Background = Brushes.DarkGray;
                        r.Cells[j].Foreground = Brushes.White;
                        r.Cells[j].BorderThickness = new Thickness(1, 1, 1, 1);
                    }
                    tableRowGroup.Rows.Add(r);
                    table.RowGroups.Add(tableRowGroup);
    
                    for (int i = 0; i < dt.Rows.Count; i++)
                    {
                        var gv = dt.Rows[i];
                        tableRowGroup = new TableRowGroup();
                        r = new TableRow();
                        for (int j = 0; j < gv.ItemArray.Length; j++)
                        {
                            r.Cells.Add(new TableCell(new System.Windows.Documents.Paragraph(new Run(gv.ItemArray[j].ToString()))));
                            r.Cells[j].ColumnSpan = 4;
                            r.Cells[j].Padding = new Thickness(4);
                            r.Cells[j].BorderBrush = Brushes.Black;
                            r.Cells[j].Background = Brushes.White;
                            r.Cells[j].Foreground = Brushes.Black;
                            r.Cells[j].BorderThickness = new Thickness(1, 1, 1, 1);
                        }
                        tableRowGroup.Rows.Add(r);
                        table.RowGroups.Add(tableRowGroup);
                    }
    
                    fd.Blocks.Add(table);
    
                    printDialog.PrintDocument(((IDocumentPaginatorSource) fd).DocumentPaginator, "");
    
                }
            }
