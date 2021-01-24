    public class Program : PMBase
    {
        public override int? ProgramIDGetter()
        {
            return this.ProjectID;
        }
        //NOTE: Database column names were from legacy changes.  I wish we could change this, but we do not have time.
        [Column("ProgramID")]
        public override int ProjectID { get; set; }
        public virtual ICollection<Project> Projects { get; set; }
        //Omitted rest of Model
        
    }
