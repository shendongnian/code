        public class Query
        {
            DataTable Source;
            Func<string, DataTable> Download;
            StringBuilder Data;
            public bool IsOwnFilter { get; set; }
            public Query(DataTable Source, Func<string, DataTable> Download, bool isOwnFilter = false)
            {
                this.Source = Source;
                this.Data = new StringBuilder();
                this.Download = Download;
                this.IsOwnFilter = isOwnFilter;
            }
            public async Task Execute(strign filter, CancellationToken cancellationToken)
            {
                try
                {
                    DataTable result = await Task.Run(() => Download(filter));
                    if (cancellationToken.IsCancellationRequested) return;
                    Source.Merge(result);
                }
                catch (Exception) { }
            }
            // This is not used in your code
            private void CreateFilter(List<long> id_list)
            {
                lock (Data)
                {
                    Data.Clear();
                    Data.Append("(0");
                    foreach (var value in id_list)
                        Data.Append("," + value);
                    Data.Append(")");
                }
            }
            public string Filter
            {
                get
                {
                    return Data.ToString();
                }
            }
        }
