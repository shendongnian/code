     private void frmLocalFileTransfer_Load(object sender, EventArgs e)
        {
            try
            {
                dt.Columns.Add("Provider");
                dt.Columns.Add("DestinationPath");
                string[] folders = null;
                dt.Columns.Add("SourcePath");
                for (int i = 1; i < System.Configuration.ConfigurationManager.ConnectionStrings.Count; i++)
                {
                    string key = System.Configuration.ConfigurationManager.ConnectionStrings[i].Name;
                    string constr = System.Configuration.ConfigurationManager.ConnectionStrings[i].ConnectionString;
                    DataGridViewTextBoxColumn column = new DataGridViewTextBoxColumn();
                    folders = constr.Split('\\');
                    string newstr = (folders[folders.Length - 2]);
                    if (!newstr.Contains("BackUp"))
                    {
                        DataRow row = dt.NewRow();
                        row[dt.Columns[0].ToString()] = key;
                        row[dt.Columns[1].ToString()] = constr;
                        row[dt.Columns[2].ToString()] = constr;
                        dt.Rows.InsertAt(row, i - 1);
                    }
                }
                foreach (DataColumn dc in dt.Columns)
                {
                    DataGridViewTextBoxColumn column = new DataGridViewTextBoxColumn();
                    column.DataPropertyName = dc.ColumnName;
                    column.HeaderText = dc.ColumnName;
                    column.Name = dc.ColumnName;
                    column.SortMode = DataGridViewColumnSortMode.Automatic;
                    column.ValueType = dc.DataType;
                    GVCheckbox();
                   
                    gevsearch.Columns.Add(column);
                }
                if (gevsearch.ColumnCount == 4)
                {
                    DataGridViewButtonColumn btnColoumn = new DataGridViewButtonColumn();
                    btnColoumn.Width = 150;
                    btnColoumn.HeaderText = "Change SourcePath";
                    btnColoumn.DefaultCellStyle.Alignment = DataGridViewContentAlignment.MiddleCenter;
                    gevsearch.Columns.Insert(4, btnColoumn);
                }
                 gevsearch.DataSource = dt;
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.ToString());
            }
        }
    private void btnAddProvider_Click(object sender, EventArgs e)
        {
            try
            {
                System.Xml.XmlDocument xDoc = new System.Xml.XmlDocument();
                path = "D:\\Pandurang\\Jitendra\\LocalFileTransfer\\LocalFileTransfer
                xDoc.Load(path);
                System.Xml.XmlElement element = xDoc.CreateElement("add");
                element.SetAttribute("name", txtProviderName.Text.Trim());
                element.SetAttribute("connectionString", txtNewPath.Text.Trim());
                System.Xml.XmlElement elementBackup = xDoc.CreateElement("add");
                elementBackup.SetAttribute("name", BackUpName);
                elementBackup.SetAttribute("connectionString", txtBackupPath.Text.Trim());
                System.Xml.XmlNode node= xDoc.ChildNodes[1].ChildNodes[0];
                node.AppendChild(element);
                node.AppendChild(elementBackup);
                xDoc.Save(path);
              }
            catch (Exception ex)
            {
                MessageBox.Show(ex.ToString());
            }
        }
