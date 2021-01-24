    namespace NameSpaceName
    {
        public class VmWord
        {
            public int Id { get; set; }
    
            public string Name { get; set; }
    
            public ICollection<VmWordLocalization> Localizations { get; set; }
        }
    
        public class VmWordLocalization
        {
            public int Id { get; set; }
    
            public string Key { get; set; }  // key from your previous dictionary
    
            public string En { get; set; }
    
            public string Pl { get; set; }
        }
    }
