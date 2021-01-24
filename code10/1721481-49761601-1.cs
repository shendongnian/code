    interface IRoute
    {
      string Route { get; }
    }
    interface IRequest<T>
    {
      IRoute Route { get; }
      T Request { get; }
    }
    interface IResponse<T>
    {
      IRoute Route { get; }
      T Response { get; }
    }
    interface IServer
    {
      IResponse<T> Process<T>(IRequest<T> request);
    }
    interface IRouter
    {
      IServer GetServer(IRoute route);
    }
