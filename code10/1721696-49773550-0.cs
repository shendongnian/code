        public Form1()
        {
            InitializeComponent();
            fillData();
        }
        public void fillColumns(XElement rootValue)
        {
        docu = XDocument.Load(FILENAME);          
            if (rootValue != null)
            {
                Queue<XElement> queue = new Queue<XElement>(rootValue.Elements());
                while (queue.Count > 0)
                {
                    XElement xelement = queue.Dequeue();
                    if (xelement.HasAttributes)
                    {
                        foreach (XAttribute attribute in xelement.Attributes())
                        {
                            string sColName = xelement.Name.ToString().Trim() + "" + attribute.Name.ToString().Trim();
                            if (!string.IsNullOrEmpty(sColName) && !dt.Columns.Contains(sColName))
                            {
                                DataColumn dtCol = new DataColumn();
                                dtCol.ColumnName = sColName;
                                dt.Columns.Add(dtCol);
                            }
                        }
                    }
                    if (!xelement.HasElements && xelement.Value != null)
                    {
                        string sColName = xelement.Name.ToString().Trim();
                        if (!string.IsNullOrEmpty(sColName) && !dt.Columns.Contains(sColName))
                        {
                            DataColumn dtCol = new DataColumn();
                            dtCol.ColumnName = sColName;
                            dt.Columns.Add(dtCol);
                        }
                    }
                    if (xelement.HasElements)
                    {
                        fillColumns(xelement);
                    }
                }
            }
        }
        public void fillRows(XElement rootValue, XElement actualValue)
        {
            try
            {
                if (rootValue != null)
                {
                    Queue<XElement> queue = new Queue<XElement>(rootValue.Elements());
                    while (queue.Count > 0)
                    {
                        XElement xelement = queue.Dequeue();
                        if (xelement.Parent == actualValue)
                        {
                            if (dtRow != null)
                                dt.Rows.Add(dtRow);
                            dtRow = dt.NewRow();
                        }
                        if (xelement.HasAttributes)
                        {
                            foreach (XAttribute xattribute in xelement.Attributes())
                            {
                                string sColName = xelement.Name.ToString() + "" + xattribute.Name.ToString();
                                if (!string.IsNullOrEmpty(sColName) && dt.Columns.Contains(sColName))
                                {
                                    dtRow[sColName] = xattribute.Value;
                                }
                            }
                        }
                        if (!xelement.HasElements && xelement.Value != null && !string.IsNullOrEmpty(xelement.Value))
                        {
                            string sColName = xelement.Name.ToString().Trim();
                            if (!string.IsNullOrEmpty(sColName) && dt.Columns.Contains(sColName))
                            {
                                dtRow[sColName] = xelement.Value;
                            }
                        }
                        if (xelement.HasElements)
                        {
                            fillRows(xelement, actualValue);
                        }
                    }
                }
            }
            catch (Exception)
            {
            }
        }
        public void fillData()
        {
            docu = XDocument.Load(FILENAME);
            XElement xElement = docu.XPathSelectElement("//eventList");
            dt = new DataTable();
            fillColumns(xElement);
            fillRows(xElement, xElement);
            dataGridView1.DataSource = dt;
        }
    }
