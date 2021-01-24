     internal class Program
        {
            #region Methods
    
            private static void Main(string[] args)
            {
                // Configure the mappings
                Mapper.Initialize(cfg =>
                {
                    cfg.CreateMap<ApplicantSkillVM, ApplicantSkill>().ForMember(x => x.Skill, x => x.Ignore()).ReverseMap();
                    cfg.CreateMap<ApplicantVM, Applicant>().ReverseMap();
                });
    
    
                var config = new MapperConfiguration(cfg => cfg.CreateMissingTypeMaps = true);
                var mapper = config.CreateMapper();
    
                ApplicantVM ap = new ApplicantVM
                {
                    Name = "its me",
                    ApplicantSkills = new List<ApplicantSkillVM>
                    {
                        new ApplicantSkillVM {SomeInt = 10, SomeString = "test", Skill = new Skill {SomeInt = 20}},
                        new ApplicantSkillVM {SomeInt = 10, SomeString = "test"}
                    }
                };
    
                List<ApplicantVM> applicantVms = new List<ApplicantVM> {ap};
                // Map
                List<Applicant> apcants = Mapper.Map<List<ApplicantVM>, List<Applicant>>(applicantVms);
            }
    
            #endregion
        }
    
    
        /// Your source classes
        public class Applicant
        {
            #region Properties
    
            public List<ApplicantSkill> ApplicantSkills { get; set; }
    
            public string Name { get; set; }
    
            #endregion
        }
    
        public class ApplicantSkill
        {
            #region Properties
    
            public Skill Skill { get; set; }
    
            public int SomeInt { get; set; }
            public string SomeString { get; set; }
    
            #endregion
        }
    
        // Your VM classes
        public class ApplicantVM
        {
            #region Properties
    
            public List<ApplicantSkillVM> ApplicantSkills { get; set; }
    
            public string Description { get; set; }
            public string Name { get; set; }
    
            #endregion
        }
    
    
        public class ApplicantSkillVM
        {
            #region Properties
    
            public Skill Skill { get; set; }
    
            public int SomeInt { get; set; }
            public string SomeString { get; set; }
    
            #endregion
        }
    
        public class Skill
        {
            #region Properties
    
            public int SomeInt { get; set; }
    
            #endregion
        }
    }
