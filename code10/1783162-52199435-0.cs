    #if DEBUG
    class Something {
        readonly string s = @"
    #if CODE_DEFINED_ONLY_IF_SET
    public class IAmOnlyHappyWhenItRains{
        public int Year{get;set;}
        public string Name{get;set;}
    }
    #endif
    ";
    }
    #endif
