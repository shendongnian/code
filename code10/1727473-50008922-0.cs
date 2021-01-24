    public class Document
    {
        private int _ID
        private string _Title
        private int _ProjectID
    
        public int ID
        {
             get; set;
        }
        public string Title
        {
             get; set;
        }
        public Project ProjectDetails
        {
             get; set;
        }
    
    //Instead of using projectID, you can use ProjectDetails.ID
    }
