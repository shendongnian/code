    using System;
    using System.Data.CData.MySQL;
    using System.Data.Common;
    
    namespace TestDbProviderFactories
    {
        class Program
        {
            static void Main(string[] args)
            {
                DbProviderFactories.RegisterFactory("test", MySQLProviderFactory.Instance);
                DbProviderFactories.GetFactoryClasses(); // => 1 result; 'test'
            }
        }
    }
