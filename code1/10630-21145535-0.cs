    public class myClass
    {
        public MainModel mainM { get; set; }
        public ResumeModel resumeM { get; set; }
        public MiscModel miscM { get; set; }
        public ProgramModel progM { get; set; }
        public QuestionsModel questM { get; set; }
        public void GetAllInformation(string username)
        {
            this.mainM = new MainModel();
            this.resumeM = new ResumeModel();
            this.miscM = new MiscModel();
            this.progM = new ProgramModel();
            this.questM = new QuestionsModel();
