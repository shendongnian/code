    protected void Page_Load(object sender, EventArgs e)
        {
            string xmlValue = ""; //To read a value from a database
            if (xmlValue.Length > 0)
            {
                if (!Page.IsPostBack)
                {
                    DataSet ds = XMLToDataSet(xmlValue);
                    Table dimensionsTable = DataSetToTable(ds);
                    tablePanel.Controls.Add(dimensionsTable);
                    DataTable dt = ds.Tables["Dimensions"];
                    rowCount = dt.Rows.Count;
                    colCount = dt.Columns.Count;
                }
                else
                {
                    tablePanel.Controls.Add(DataSetToTable(DefaultDataSet(rowCount, colCount)));
                }
            }
            else
            {
                if (!Page.IsPostBack)
                {
                    rowCount = 2;
                    colCount = 4;
                }
                else
                {
                    if (GetPostBackControl(this.Page).ID == "addRow")
                    {
                        rowCount = rowCount + 1;
                    }
                    else if (GetPostBackControl(this.Page).ID == "addColumn")
                    {
                        colCount = colCount + 1;
                    }
                }
                tablePanel.Controls.Add(DataSetToTable(DefaultDataSet(rowCount, colCount)));
            }
        }
        protected void submit_Click(object sender, EventArgs e)
        {
            resultsLabel.Text = Server.HtmlEncode(DataSetToStringXML(TableToDataSet((Table)tablePanel.Controls[0])));
        }
        protected void addColumn_Click(object sender, EventArgs e)
        {
            
        }
        protected void addRow_Click(object sender, EventArgs e)
        {
            
        }
        public DataSet TableToDataSet(Table table)
        {
            DataSet ds = new DataSet();
            DataTable dt = new DataTable("Dimensions");
            ds.Tables.Add(dt);
            //Add headers
            for (int i = 0; i < table.Rows[0].Cells.Count; i++)
            {
                DataColumn col = new DataColumn();
                TextBox headerTxtBox = (TextBox)table.Rows[0].Cells[i].Controls[0];
                col.ColumnName = headerTxtBox.Text;
                col.Caption = headerTxtBox.Text;
                dt.Columns.Add(col);
            }
            
            for (int i = 0; i < table.Rows.Count; i++)
            {
                DataRow valueRow = dt.NewRow();
                for (int x = 0; x < table.Rows[i].Cells.Count; x++)
                {
                    TextBox valueTextBox = (TextBox)table.Rows[i].Cells[x].Controls[0];
                    valueRow[x] = valueTextBox.Text;
                }
                dt.Rows.Add(valueRow);
            }
            return ds;
        }
        public Table DataSetToTable(DataSet ds)
        {
            DataTable dt = ds.Tables["Dimensions"];
            Table newTable = new Table();
            //Add headers
            TableRow headerRow = new TableRow();
            for (int i = 0; i < dt.Columns.Count; i++)
            {
                TableCell headerCell = new TableCell();
                TextBox headerTxtBox = new TextBox();
                headerTxtBox.ID = "HeadersTxtBox" + i.ToString();
                headerTxtBox.Font.Bold = true;
                headerTxtBox.Text = dt.Columns[i].ColumnName;
                headerCell.Controls.Add(headerTxtBox);
                headerRow.Cells.Add(headerCell);
            }
            newTable.Rows.Add(headerRow);
            //Add value rows
            for (int i = 0; i < dt.Rows.Count; i++)
            {
                TableRow valueRow = new TableRow();
                for (int x = 0; x < dt.Columns.Count; x++)
                {
                    TableCell valueCell = new TableCell();
                    TextBox valueTxtBox = new TextBox();
                    valueTxtBox.ID = "ValueTxtBox" + i.ToString() + i + x + x.ToString();
                    valueTxtBox.Text = dt.Rows[i][x].ToString();
                    valueCell.Controls.Add(valueTxtBox);
                    valueRow.Cells.Add(valueCell);
                }
                newTable.Rows.Add(valueRow);
            }
            return newTable;
        }
        public DataSet DefaultDataSet(int rows, int cols)
        {
            DataSet ds = new DataSet();
            DataTable dt = new DataTable("Dimensions");
            ds.Tables.Add(dt);
            DataColumn nameCol = new DataColumn();
            nameCol.Caption = "Name";
            nameCol.ColumnName = "Name";
            nameCol.DataType = System.Type.GetType("System.String");
            dt.Columns.Add(nameCol);
            DataColumn widthCol = new DataColumn();
            widthCol.Caption = "Width";
            widthCol.ColumnName = "Width";
            widthCol.DataType = System.Type.GetType("System.String");
            dt.Columns.Add(widthCol);
            if (cols > 2)
            {
                DataColumn heightCol = new DataColumn();
                heightCol.Caption = "Height";
                heightCol.ColumnName = "Height";
                heightCol.DataType = System.Type.GetType("System.String");
                dt.Columns.Add(heightCol);
            }
            if (cols > 3)
            {
                DataColumn depthCol = new DataColumn();
                depthCol.Caption = "Depth";
                depthCol.ColumnName = "Depth";
                depthCol.DataType = System.Type.GetType("System.String");
                dt.Columns.Add(depthCol);
            }
            if (cols > 4)
            {
                int newColCount = cols - 4;
                for (int i = 0; i < newColCount; i++)
                {
                    DataColumn newCol = new DataColumn();
                    newCol.Caption = "New " + i.ToString();
                    newCol.ColumnName = "New " + i.ToString();
                    newCol.DataType = System.Type.GetType("System.String");
                    dt.Columns.Add(newCol);
                }
            }
            for (int i = 0; i < rows; i++)
            {
                DataRow newRow = dt.NewRow();
                newRow["Name"] = "Name " + i.ToString();
                newRow["Width"] = "Width " + i.ToString();
                if (cols > 2)
                {
                    newRow["Height"] = "Height " + i.ToString();
                }
                if (cols > 3)
                {
                    newRow["Depth"] = "Depth " + i.ToString();
                }
                dt.Rows.Add(newRow);
            }
            return ds;
        }
        public DataSet XMLToDataSet(string xml)
        {
            StringReader sr = new StringReader(xml);
            DataSet ds = new DataSet();
            ds.ReadXml(sr);
            return ds;
        }
        public string DataSetToStringXML(DataSet ds)
        {
            XmlDocument _XMLDoc = new XmlDocument();
            _XMLDoc.LoadXml(ds.GetXml());
            StringWriter sw = new StringWriter();
            XmlTextWriter xw = new XmlTextWriter(sw);
            XmlDocument xml = _XMLDoc;
            xml.WriteTo(xw);
            return sw.ToString();
        }
        private int rowCount
        {
            get { return (int)ViewState["rowCount"]; }
            set { ViewState["rowCount"] = value; }
        }
        private int colCount
        {
            get { return (int)ViewState["colCount"]; }
            set { ViewState["colCount"] = value; }
        }
        public static Control GetPostBackControl(Page page)
        {
            Control control = null;
            string ctrlname = page.Request.Params.Get("__EVENTTARGET");
            if (ctrlname != null && ctrlname != string.Empty)
            {
                control = page.FindControl(ctrlname);
            }
            else
            {
                foreach (string ctl in page.Request.Form)
                {
                    Control c = page.FindControl(ctl);
                    if (c is System.Web.UI.WebControls.Button)
                    {
                        control = c;
                        break;
                    }
                }
            }
            return control;
        }
