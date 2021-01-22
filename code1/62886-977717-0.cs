    class CustomObjectViewModel : ViewModelBase
    {
        protected readonly CustomObject CustomObject;
    
        public CustomObjectViewModel( CustomObject customObject )
        {
            CustomObject = customObject;
        }
    
        public string Title
        {
            // implementation excluded for brevity
        }
    }
    
    class CustomItemViewModel : CustomObjectViewModel 
    {
        protected CustomItem CustomItem  { get { return (CustomItem)CustomObject; } }
    
        public CustomItemViewModel( CustomItem customItem )
            :base(customItem)
        {
        }
    }
