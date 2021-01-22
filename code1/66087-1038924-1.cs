    public class Search : ISearch
    {
        delegate DataTable SearchAsync(int stypeid, string term, int? cid, int? sid);
        List<DataTable> tables;
    
        private void ProcessCallBack(IAsyncResult result)
        {
            AsyncResult asyncResult = (AsyncResult)result;
            SearchAsync async = (SearchAsync)asyncResult.AsyncDelegate;
    
            if(tables == null)
            {
                tables = new List<DataTable>();
            }
    
            try
            {
                tables.Add(async.EndInvoke(result));
            }
            catch(Exception ex)
            {
                /* handle error */
                tables.Add(null);
            }
        }
    
        public DataTable SearchIndex(int stypeid, string term, int? cid, int? sid) 
        {/* do search */}
    
        public DataTable SerachGlobal(string term, int? cid, int? sid)
        {
            List<SearchTypes> types ...; /* load types from db */
            SearchAsync async = new SearchAsync(SearchIndex);
            AsyncCallback callBack = new AsyncCallback(ProcessCallBack);
    
            foreach(SearchType t in types)
            {
                async.BeginInvoke(t.searchtypeid, term, cid, sid, callBack, null);
            }
    
            do
            {
                Thread.Sleep(100);
            }
            while(tables == null || tables.Count < types.Count);
    
            /* combine the tables */
    
        }
    }
