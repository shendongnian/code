    public class DataType
    {
    }
    public interface IDataManager
    {
        DataType GetDataByIdNameAge(uint id, string name, int age);
    }
    public class DataManager : IDataManager
    {
        public DataType GetDataByIdNameAge(uint id, string name, int age)
        {
            return null;
        }
    }
    public class Builder
    {
        // Creates multiple Office objects
        public void Create()
        {
            var office = new Office(new DataManager());
        }
    }
    public class Office
    {
        private IDataManager dataManager;
        public Office(IDataManager dataManager)
        {
            this.dataManager = dataManager;
        }
        public void DoSomething()
        {
            DataType dataType = dataManager.GetDataByIdNameAge(1, "SomeName", 18);
        }
    }
