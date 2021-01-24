    public interface IDataItem {
    
        IEnumerable<string> Children { get; set; }
        void Wipe();
    }
    
    public class DataItem : IDataItem {
    
        public Collection<string> Children { get; } = new Collection<string>(); 
        public void Wipe() {
            Children.ClearItems();  //Property exists on Collection, but not on IEnumerable
        }
    }
