    public class ResponseEntryViewModel
    {
        public int TypeID { get; set; }
        public string TypeName { get; set; }
        public int User_ID { get; set; }
        public List<SectionDataModel> Sections { get; set; }
        public ResponseEntryViewModel(SectionDataModel obj)
        {
            Sections = new List<SectionDataModel>();
            Sections.Add(obj);
        }
        public class SectionDataModel
        {
            public int SectionID { get; set; }
            public string Name { get; set; }
            public string Status { get; set; }
            public int TypeId { get; set; }
            public List<SubSectionModel> SubSections { get; set; }
            public SectionDataModel(SubSectionModel obj)
            {
                SubSections = new List<SubSectionModel>();
                SubSections.Add(obj);
            }
        }
        public class SubSectionModel
        {
            public int SubSectionID { get; set; }
            public string Name { get; set; }
            public string Status { get; set; }
            public int SectionId { get; set; }
            public List<QuestionModel> QuestionsList { get; set; }
            public SubSectionModel(QuestionModel obj)
            {
                QuestionsList = new List<QuestionModel>();
                QuestionsList.Add(obj);
            }
        }
        public class QuestionModel
        {
            public int SubSectionID { get; set; }
            public int QuestionID { get; set; }
            public string Question { get; set; }
        }
    }
