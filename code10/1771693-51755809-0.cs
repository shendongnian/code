    public class SectionsResponse
    {
        public List<SectionDTO> Sections {get;set;}
    }
    
    public class SectionDTO
    {
        public string SectionID {get;set;}
        .... add other properties
        public List<ContentDTO> sectionContent {get;set;}
    }
    
    public class ContentDTO
    {
       ... define your properties
    }
