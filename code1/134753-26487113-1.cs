            int totalRows;
            int pageIndex = RowIndex / PageSize;
            List<Data> data= new List<Data>();
            IEnumerable<Data> dataPage;
            bool asc = !SortExpression.Contains("DESC");
            switch (SortExpression.Split(' ')[0])
            {
                case "ColumnName":
                    dataPage = DataContext.Data.Page(pageIndex, PageSize, p => p.ColumnName, asc, out totalRows);
                    break;
                default:
                    dataPage = DataContext.vwClientDetails1s.Page(pageIndex, PageSize, p => p.IdColumn, asc, out totalRows);
                    break;
            }
            foreach (var d in dataPage)
            {
                clients.Add(d);
            }
            return data;
        }
        public int CountAll()
        {
            return DataContext.Data.Count();
        }
