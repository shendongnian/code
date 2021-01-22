    public class PagedGrid : DataGridView
        {
            Paging pg;
            SQLQuery s;
            public void SetPagedDataSource(  SQLQuery s, BindingNavigator bnav)
            {
                this.s = s;
                int count = DataProvider.ExecuteCount(s.CountQuery);
                pg = new Paging(count, 5);
                bnav.BindingSource = pg.BindingSource;
                pg.BindingSource.PositionChanged += new EventHandler(bs_PositionChanged);
                //first page
                string q = s.GetPagingQuery(pg.GetStartRowNum(1), pg.GetEndRowNum(1), true);
                DataTable dt = DataProvider.ExecuteDt(q);
                DataSource = dt;
            }
    
            void bs_PositionChanged(object sender, EventArgs e)
            {
                int pos = ((BindingSource)sender).Position + 1;
                string q = s.GetPagingQuery(pg.GetStartRowNum(pos), pg.GetEndRowNum(pos), false);
                DataTable dt = DataProvider.ExecuteDt(q);
                DataSource = dt;
            }
    
            public void UpdateData()
            {
                DataTable dt = (DataTable)DataSource;
                using (SqlConnection con = new SqlConnection(DataProvider.conStr))
                {
                    con.Open();
                    SqlDataAdapter da = new SqlDataAdapter(s.CompleteQuery, con);
                    SqlCommandBuilder cb = new SqlCommandBuilder(da);
                    da.UpdateCommand = cb.GetUpdateCommand();
                    da.InsertCommand = cb.GetInsertCommand();
                    da.DeleteCommand = cb.GetDeleteCommand();
                    da.Update(dt);
                }
                MessageBox.Show("The changes are committed to database!");
            }
        }
    
    
      /// <summary>
        /// Gives functionality of next page , etc for paging.
        /// </summary>
        public class Paging
        {
            public int _totalSize = 0;
            private int _pageSize = 0;
    
            public int TotalSize
            {
                get
                {
                    return _totalSize;
                }
                set
                {
                    if (value <= 0)
                    {
                        throw new ArgumentException();
                    }
                    _totalSize = value;
                }
            }
    
            public int PageSize
            {
                get
                {
                    return _pageSize;
                }
                set
                {
                    if (value <= 0)
                    {
                        throw new ArgumentException();
                    }
                    _pageSize = value;
                }
            }
    
            public Paging(int totalSize, int pageSize)
            {
                this.TotalSize = totalSize;
                this.PageSize = pageSize;
            }
    
            public int GetStartRowNum(int PageNum)
            {
                if (PageNum < 1)
                {
                    throw new Exception("Page number starts at 1");
                }
                if (PageNum > GetPageCount())
                {
                    throw new Exception("Page number starts at " + GetPageCount().ToString());
                }
                return 1 + ((PageNum - 1) * _pageSize);
            }
    
            public int GetEndRowNum(int PageNum)
            {
                if (PageNum < 1)
                {
                    throw new Exception("Page number starts at 1");
                }
                if (PageNum > GetPageCount())
                {
                    throw new Exception("Page number starts at " + GetPageCount().ToString());
                }
                return _pageSize + ((PageNum - 1) * _pageSize);
            }
    
            public int GetPageCount()
            {
                return (int)Math.Ceiling(TotalSize / (decimal)PageSize);
            }
    
            public bool IsFirstPage(int PageNum)
            {
                if (PageNum == 1)
                {
                    return true;
                }
                return false;
            }
    
            public bool IsLastPage(int PageNum)
            {
                if (PageNum == GetPageCount())
                {
                    return true;
                }
                return false;
            }
            private int _currentPage = 1;
            public int CurrentPage
            {
                get
                {
                    return _currentPage;
                }
                set
                {
                    _currentPage = value;
                }
            }
            public int NextPage
            {
                get
                {
                    if (CurrentPage + 1 <= GetPageCount())
                    {
                        _currentPage = _currentPage + 1;
                    }
                    return _currentPage;
                }
            }
    
            public int PreviousPage
            {
                get
                {
                    if (_currentPage - 1 >= 1)
                    {
                        _currentPage = _currentPage - 1;
                    }
                    return _currentPage;
                }
            }
            private BindingSource _bindingSource = null;
            public BindingSource BindingSource
            {
                get
                {
                    if (_bindingSource == null)
                    {
                        _bindingSource = new BindingSource();
                        List<int> test = new List<int>();
                        for (int i = 0; i < GetPageCount(); i++)
                        {
                            test.Add(i);
                        }
                        _bindingSource.DataSource = test;
                    }
                    return _bindingSource;
                }
    
            }
        }
    
    
        /// <summary>
        /// Query Helper of Paging
        /// </summary>
        public class SQLQuery
        {
    
            private string IDColumn = "";
            private string WherePart = " 1=1 ";
            private string FromPart = "";
            private string SelectPart = "";
    
            public SQLQuery(string SelectPart, string FromPart, string WherePart, string IDColumn)
            {
                this.IDColumn = IDColumn;
                this.WherePart = WherePart;
                this.FromPart = FromPart;
                this.SelectPart = SelectPart;
    
            }
    
            public string CompleteQuery
            {
                get
                {
                    if (WherePart.Trim().Length > 0)
                    {
                        return string.Format("Select {0} from {1} where {2} ", SelectPart, FromPart, WherePart);
                    }
                    else
                    {
                        return string.Format("Select {0} from {1} ", SelectPart, FromPart);
                    }
                }
            }
    
            public string CountQuery
            {
                get
                {
                    if (WherePart.Trim().Length > 0)
                    {
                        return string.Format("Select count(*) from {0} where {1} ", FromPart, WherePart);
                    }
                    else
                    {
                        return string.Format("Select count(*) from {0} ", FromPart);
    
                    }
                }
            }
    
         
    
            public string GetPagingQuery(int fromrow, int torow, bool isSerial)
            {
                fromrow--;
                if (isSerial)
                {
                    return string.Format("{0} where {1} >= {2} and {1} <= {3}", CompleteQuery, IDColumn, fromrow, torow);
                }
                else
                {
                    string select1 = "";
                    string select2 = "";
                    if (WherePart.Trim().Length > 0)
                    {
                        select1 = string.Format("Select top {3} {0} from {1} where {2} ", SelectPart, FromPart, WherePart, torow.ToString());
                        select2 = string.Format("Select top {3} {0} from {1} where {2} ", SelectPart, FromPart, WherePart, fromrow.ToString());
                    }
                    else
                    {
                        select1 = string.Format("Select top {2} {0} from {1} ", SelectPart, FromPart, torow.ToString());
                        select2 = string.Format("Select top {2} {0} from {1} ", SelectPart, FromPart, fromrow.ToString());
                    }
                    if (fromrow <= 1)
                    {
                        return select1;
                    }
                    else
                    {
                        return string.Format("{0} except {1} ", select1, select2);
                    }
    
                }
            }
    
    
        }
