    public class emp {
        public int Id { get; set; }
        public string Name { get; set; }
        public int DepartmentId { get; set; }
        public IList<empDetail> Details { 
            get {
                return _details;
            }
        }
        private IList<empDetail> _details;
        public IList<empDocument> Documents {
            get {
                return _documents;
            }
        }
        private IList<empDocument> _documents;
    }
