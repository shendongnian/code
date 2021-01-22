    interface IGraphDataCacheService<T> {
    
    IGraphData<T> Get(string identifier);
    void Set(IGraphData<T> graphData);
    
    }
    
    
    public sealed class GraphDataCacheServiceImpl<T> : IGraphDataCacheService<T>
    {
    
      private GraphDataCacheServiceImpl()
      {
          // ..
      }
    
      static GraphDataCacheServiceImpl()
      {
        Instance = new GraphDataCacheServiceImpl<T>();
      }
    
      public IGraphData<T> Get(string id)
      {
          return new GraphDataImpl<T>();
      }
    
      public void Set(IGraphData<T> graphData)
      {
      }
    
      public static GraphDataCacheServiceImpl<T> Instance {get; private set;}
    }
