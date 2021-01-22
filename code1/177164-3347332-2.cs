    class Person : INotifyPropertyChanged
    {
        // "notify" is a context keyword, same as "get" and "set"
        public string Name { get; set; notify; }
    }
