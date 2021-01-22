    using System; 
    using System.Collections.Generic; 
    using System.Text; 
    using Ninject.Core;
    
    namespace Forecast.Domain.Implementation 
    {
        public class NinjectBaseModule : StandardModule
        {
            public override void Load()
            {
                Bind<ICountStocks>().To<Holding>();
                Bind<IOwn>().To<Portfolio>();
                Bind<ICountMoney>().To<Wallet>();
            }
        } 
    }
