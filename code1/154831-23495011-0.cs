    public class SuperGrid : DataGridView
        {
            public int PageSize
            {
                get
                {
                    return _pageSize;
                }
                set
                {
                    _pageSize = value;
                }
            }
            public int _pageSize = 10;
            BindingSource bs = new BindingSource();
            BindingList<DataTable> tables = new BindingList<DataTable>();
            public void SetPagedDataSource(DataTable dataTable, BindingNavigator bnav)
            {
                DataTable dt = null;
                int counter = 1;
                foreach (DataRow dr in dataTable.Rows)
                {
                    if (counter == 1)
                    {
                        dt = dataTable.Clone();
                        tables.Add(dt);
                    }
                    dt.Rows.Add(dr.ItemArray);
                    if (PageSize < ++counter  )
                    {
                        counter = 1;
                    }
                }
                bnav.BindingSource = bs;
                bs.DataSource = tables;
                bs.PositionChanged += bs_PositionChanged;
                bs_PositionChanged(bs, EventArgs.Empty);
            }
            void bs_PositionChanged(object sender, EventArgs e)
            {
                this.DataSource = tables[bs.Position];
            }
        }
