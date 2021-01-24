    public class ProjectViewModel
    {
        public Guid Id { get; set; }
    
        private List<ProjectDetailAnswertViewModel> _answerss = new List<ProjectDetailAnswertViewModel>();    
        public List<ProjectDetailAnswertViewModel> Answers
        { 
            get {return _answers; }
            set {_answers = value; } 
        }
    }
    
    public class ProjectDetailAnswertViewModel
    {
        public Guid Id {get; set;}
        public string DetailDescription {get; set;}
        public string Description {get; set;}
    }
