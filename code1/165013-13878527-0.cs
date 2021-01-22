    public long GetPageID()
    {
        long pageid = new long();
              
        Ektron.Cms.PageBuilder.PageBuilder myPage = this.Page as Ektron.Cms.PageBuilder.PageBuilder;
                    if (myPage != null)
                    {
    
                        pageid = myPage.Pagedata.pageID;
                    }
            
    }
