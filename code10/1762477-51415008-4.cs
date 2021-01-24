    public class ProjectViewModel
    {
        public Guid Id { get; set; }
    
        private List<ProjectDetailViewModel> _details = new List<ProjectDetailViewModel>();    
        public List<ProjectDetailViewModel> Details 
        { 
            get {return _details; }
            set {_details = value; } 
        }
    }
    
    public class ProjectDetailViewModel
    {
        public Guid Id {get; set;}
        public string Description {get; set;}
    
    private List<AnswerViewModel> _answers = new List<AnswerViewModel>();    
        public List<AnswerViewModel> Answers 
        { 
            get {return _answers; }
            set {_answers = value; } 
        }
    }
    
    public class AnswerViewModel
    {
        public Guid Id {get; set;}
        public string Description {get; set;}
    }
