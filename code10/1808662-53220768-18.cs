    interface IStrategy
    {
        string Name { get;  }
        void DoWork();
    }
    abstract class StrategyBase : IStrategy
    {
        private IBusinessLogic _businessLogic;
        private IApplicationLogic _applicationLogic;
        public string Name { get; private set; }
        
        protected StrategyBase(String name, IBusinessLogic businessLogic, IApplicationLogic applicationLogic)
        {
            this.Name = name;
            _businessLogic = businessLogic;
            _applicationLogic = applicationLogic;
        }
        public void DoWork()
        {
            _businessLogic.DoBusinessLogic();
            _applicationLogic.DoApplicationLogic();
        }
    }    
    class TypeAStrategy : StrategyBase
    {
        public TypeAStrategy(String name, ITypeABusinessLogic businessLogic, ITypeAApplicationLogic applicationLogic) : base(name, businessLogic, applicationLogic)
        { }
    }
    class TypeBStrategy : StrategyBase
    {
        public TypeBStrategy(String name, ITypeBBusinessLogic businessLogic, ITypeBApplicationLogic applicationLogic) : base(name, businessLogic, applicationLogic)
        { }
    }
