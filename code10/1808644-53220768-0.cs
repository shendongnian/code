    interface IBusinessLogic
    {
        void DoBusinessLogic();
    }
    interface ITypeABusinessLogic : IBusinessLogic { }
    interface ITypeBBusinessLogic : IBusinessLogic { }
    interface IApplicationLogic
    {
        void DoApplicationLogic();
    }
    interface ITypeAApplicationLogic : IApplicationLogic { }
    interface ITypeBApplicationLogic : IApplicationLogic { }
