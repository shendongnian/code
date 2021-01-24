    public class LanguageSchool
    {
        public int LanguageSchoolId { get; set; }
        public virtual ICollection<LanguageSchoolProgram> LanguageSchoolPrograms { get; set; }
    }
            
    public class LanguageSchoolProgram
    {
        public int LanguageSchoolProgramId { get; set; }
        public string ProgramName {get; set;} // this is X, Y or Z
        public virtual ICollection<LanguageSchool> LanguageSchools { get; set; }
    }
       
