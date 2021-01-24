    public enum QueryTypes
    {
        Alias
    }
    public class CustomQueryModel
    {
        public string Alias
        {
            get;
            set;
        }
        public QueryTypes Type
        {
            get;
            set;
        }
    }
    public class ResultModel
    {
    }
    public interface ICustomClient
    {
        IEnumerable<ResultModel> GetAccountByAlias(IEnumerable<CustomQueryModel> query, CancellationToken cancellationToken);
    }
    public class ClassUnderTest
    {
        private readonly ICustomClient client;
        public ClassUnderTest(ICustomClient client)
        {
            this.client = client;
        }
        public IEnumerable<ResultModel> MethodConsumingGetAccountByAlias(IEnumerable<CustomQueryModel> queries, CancellationToken cancellationToken)
        {
            // Do whatever your class does before / after it calls client.GetAccountByAlias
            return this.client.GetAccountByAlias(queries, cancellationToken);
        }
    }
