    public interface IDataItem 
    {
        void OnlyUseThis();
    }
    public class DataItem : IDataItem
    {
        public void OnlyUseThis()
        {  
            // externaly available
        }
        public void ResetStatus()
        {
            // hands off
        }
    }
