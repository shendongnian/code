    class MyClass
    {
        [JsonConverter(typeof(SqlHierarchyIdConverter))]
        public SqlHierarchyId NodeId { get; set; }
    }
