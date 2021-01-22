    namespace Shared
    {
        public interface IFoo
        {
            string Name{get;set;}
        }
        public interface IFooMgr {
            IList<IFoo> GetList();
        }
    }
