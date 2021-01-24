    public interface ISettingsMenu
    {
        string Name { set; get; }
    
        IEnumerable<object> Items { get; }
    
       void AddItem(object item);
    }
    
    
    public class SettingsMenu<T> : ISettingsMenu
    {
        public string Name { set; get; }
    
        public ObservableCollection<T> Items { set; get; }
    
        IEnumerable<object>  ISettingsMenu.Items
        {
            get { return Items.Cast<object>(); }
        }
        
        public void AddItem(object item)
        {
            throw new System.NotImplementedException();
        }
    
        public SettingsMenu()
        {
            Name = "";
            Items = new ObservableCollection<T>();
        }
    
        public SettingsMenu(string _name, ObservableCollection<T> _items)
        {
            Name = _name;
            Items = _items;
        }
    
        public void AddItem(T _item)
        {
            Items.Add(_item);
        }
    }
