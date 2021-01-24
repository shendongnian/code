    public abstract class ConfigBase   {  }
    public class FtpConfig : ConfigBase
    {
        public string Uri { get; set; }
    }
    public class AzureConfig : ConfigBase
    {
        public string AccountName { get; set; }
    }
    public abstract class StorageStrategyBase    { }
    public abstract class StorageStragegyBase<T> : StorageStrategyBase where T: ConfigBase
    {
        public abstract void Init(T config);
    }
    public class FtpStrategy : StorageStragegyBase<FtpConfig>
    {
        public override void Init(FtpConfig config)
        {
            var myUri = config.Uri;
        }
    }
    public static class StrategyFactory
    {
        public static TStrategy  GetStrategy<TStrategy,TConfig>(TConfig config) where TStrategy : StorageStragegyBase<TConfig>, new() where TConfig : ConfigBase
        {
            var s = new TStrategy();
            s.Init(config);
            return s;
        }
    }
    class Program
    {
        static void Main(string[] args)
        {
            var myFtpStrategy = StrategyFactory.GetStrategy<FtpStrategy, FtpConfig>(new FtpConfig { Uri = "my url" });
        }
    }
