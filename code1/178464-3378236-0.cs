    public interface ICoreEntity { }
    public class DataObject: ICoreEntity { }
    
    public interface IMyControl<out T> where T : ICoreEntity
    {
        T GetEntity();
    }
    
    public class MyControl : IMyControl<DataObject>   // DataObject implements ICoreEntity
    {
        public DataObject GetEntity()
        {
            throw new NotImplementedException();
        }
    }
