    public class AppRoleAssignmentsRoot
    {
        public string odatametadata { get; set; }
        public AppRoleAssignment[] value { get; set; }
    }
    public class AppRoleAssignment
    {
        public string odatatype { get; set; }
        public string objectType { get; set; }
        public string objectId { get; set; }
        public object deletionTimestamp { get; set; }
        public object creationTimestamp { get; set; }
        public string id { get; set; }
        public string principalDisplayName { get; set; }
        public string principalId { get; set; }
        public string principalType { get; set; }
        public string resourceDisplayName { get; set; }
        public string resourceId { get; set; }
    }
