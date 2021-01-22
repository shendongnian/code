    public interface IReportReposSpec
    {
          void Is(object value)
          
          // stored proc translation of the spec
          string Param {get;}
          string DbType {get;}
          string Value {get;}
    }
