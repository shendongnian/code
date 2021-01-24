    interface IApplicationModelFactory
    {
        ApplicationModel[] Model { get; }
    }
    class ApplicationModelFactory : IApplicationModelFactory
    {
        public ApplicationModel[] Model { get; set; }
    }
