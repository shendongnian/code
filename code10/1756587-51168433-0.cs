    [DataContract]
    class ReactiveProfile : ReactiveObject
    {
        [IgnoreDataMember]
        private string _name;
        [DataMember]
        public string Name
        {
            get => _name;
            set => this.RaiseAndSetIfChanged(ref _name, value);
        }
    }
