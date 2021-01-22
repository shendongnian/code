    internal class ProductionModule : StandardModule
    {
        public override void Load()
        {
            Bind<IDataGateway>().To<DataGateWay>();
        }
    }
