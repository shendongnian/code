    class BLL {
        ...
    
        public IEnumerable<Post> Posts {
            get {
                DataSet ds = DbProvider.Instance().Post_ListRecent(); 
                foreach (DataRow row in ds.Tables[0].Rows) 
                { 
                    Post oPost = new Post(); 
                    oPost.OpenRecentInitFromRow(row); 
                    yield return oPost;
                } 
            }
        }    
    
        ...
    }
