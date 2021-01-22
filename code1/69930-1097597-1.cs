    public class Project
    {
        private Project(Guid v) { Value = v; }
        public Guid Value { get; private set; }
        public static readonly Project Cleanup =
            new Project(new Guid("47801daa-7437-4bfe-a240-9f7c583018a4"));
        public static readonly Project Maintenence =
            new Project(new Guid("2548a7f3-7bf4-4533-a6c1-dcbcfcdc26a5"));
        public static readonly Project Upgrade =
            new Project(new Guid("ed3c3e73-8e6a-4c09-84ae-7f0876d194aa"));
        // etc
    }
