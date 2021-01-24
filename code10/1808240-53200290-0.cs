    public class JiraResponse
    {
        public class JiraResponseProject
        {
            public string Key { get; set; }
        }
        
        public class JiraResponseIssueType
        {
            public string Name { get; set; }
        }
        
        private JiraResponseProject _project = new JiraResponseProject();
        private JiraResponseIssueType _issueType = new JiraResponseIssueType();
        
        public JiraResponseProject Project => _project;
        public JiraResponseIssueType IssueType => _issueType;
        
        public string Summary { get; set; }
        public string Description { get; set; }    
    }
