    public class Program
    {
    	[Key]
        public int Id {get;set;}
        public virtual ICollection<ProgramAssembly> Assemblies {get;set;}
    }
    
    public class ProgramAssembly
    {
       public int Id {get;set;}
       
       [ForeignKey("ProgramId")]
       public virtual Program Program {get;set;}
       public int ProgramId {get;set;}
       public bool IsMainProgramAssembly
    }
