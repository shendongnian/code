    public class Program
    {
        [Key]
        public int Id {get;set;}
        public int MainAssemblyId {get;set;}
        [ForeignKey("MainAssemblyId ")]
        public virtual ProgramAssembly MainAssembly {get;set;}
        public virtual ICollection<ProgramAssembly> Assemblies {get;set;}
    }
    public class ProgramAssembly
    {
       [Key]
       public int Id {get;set;}
       [ForeignKey("ProgramId")]
       public virtual Program Program {get;set;}
       public int ProgramId {get;set;}
    }
