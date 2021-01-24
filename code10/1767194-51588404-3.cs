    public interface IDataItem {
    
        void DoStuff(string value);
    }
    
    public class DataItem : IDataItem {
    
        public void DoStuff(object value) { }
    }
