     public class PagingList<T>
            {
                public BindingList<T> Collection { get; set; }
                public int Count { get; set; }
    
                public PagingList()
                {
                    Collection = new BindingList<T>();
                    Count = 0;
                }
                
            }
    
            public void CallRenderListingsRows()
            {
                var pagingList = new PagingList<PostcodeDetail>();
    
                RenderListingsRows(pagingList.Collection);
            }
    
            protected void RenderListingsRows(BindingList<PostcodeDetail> list)
            {
                foreach (var item in list)
                {
                    //render stuff
                }
            }
