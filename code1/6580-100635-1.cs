    public partial class MyEntity
    {
        public bool IsLoaded { get; private set; }
        partial void OnLoaded()
        {
            IsLoaded = true;
        }
    }
