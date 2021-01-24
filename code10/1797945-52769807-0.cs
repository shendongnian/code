    interface IDataProvider
    {
        void GetData();
    }
    
    abstract class StandardDataProvider : IDataProvider
    {
        public virtual void GetData()
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
    
        public void GetBaseData()
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
            if (dataprovider is ManagedDataProvider)
                {
                    (dataprovider as ManagedDataProvider).GetBaseData();
                }
            
    
            Console.ReadLine();
        }
    }
