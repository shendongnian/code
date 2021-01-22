    public void LoadAllPagesExpandAll(DataHelperReturnHandler handler, string orderby) 
    { 
      DataServiceCollection<CmsPage> data = new   DataServiceCollection<CmsPage>( _dataservice );
     
      DataServiceQuery<CmsPage> theQuery = _dataservice 
          .CmsPages 
          .Expand("CmsChildPages") 
          .Expand("CmsParentPage") 
          .Expand("CmsItemState") 
          .AddQueryOption("$orderby", orderby); 
     
      theQuery.BeginExecute( 
          delegate(IAsyncResult asyncResult) 
          { 
        _callback_dispatcher.BeginInvoke( 
          () => 
          { 
              try 
              { 
            DataServiceQuery<CmsPage> query = asyncResult.AsyncState as DataServiceQuery<CmsPage>; 
            if (query != null) 
            { 
                //create a tracked DataServiceCollection from the result of the asynchronous query. 
                QueryOperationResponse<CmsPage> queryResponse = query.EndExecute(asyncResult) as QueryOperationResponse<CmsPage>; 
                data.Load(queryResponse); 
     
                handler(data); 
            } 
              } 
              catch 
              { 
            handler(data); 
              } 
          } 
            ); 
          }, 
          theQuery 
      ); 
    } 
