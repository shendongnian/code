    interface IDataProvider
    {
        void GetData();
        void GetBaseData();
    }
    
    abstract class StandardDataProvider : IDataProvider
    {
        public virtual void GetData()
        {
            Console.WriteLine("GetData_StandardDataProvider");
        }
    
        public virtual void GetBaseData()
        {
            Console.WriteLine("GetData_StandardDataProvider");
        }
    }
    
    class ManagedDataProvider : StandardDataProvider
    {
    
        public override void GetData()
        {
            Console.WriteLine("GetData_ManagedDataProvider");
        }
    
        public override void GetBaseData()
        {
            base.GetData();
        }
    }
    
    
    
    class Program
    {
        static void Main(string[] args)
        {
    
            IDataProvider dataprovider = new ManagedDataProvider();
    
            dataprovider.GetData();
            dataprovider.GetBaseData();            
    
            Console.ReadLine();
        }
    }
