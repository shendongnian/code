    public interface IReportFactory
    {
        object Create();
    }
    
    public class ReportFactory1 : IReportFactory
    {
        public object Create()
        {
            return new { F = 1, };
        }
    }
    public class ReportFactory2 : IReportFactory {
        public object Create()
        {
            return new { F = 2, }; 
        }
    }
