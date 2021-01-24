    public class Project : PMBase
    {
        public override int? ProgramIDGetter()
        {
            return this.ProgramID;
        }
        [Display(Name = "Program Number & Name")]
        public override int? ProgramID { get; set; }
        //Omitted rest of Model
    }
