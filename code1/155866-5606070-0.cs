    [ToolboxItem(true)]
    public class myClassList : BindingList<myClass> , IComponent 
    {
        public event EventHandler Disposed;
        public ISite Site { get; set; }
        public void Dispose()
        {
        }
    }
