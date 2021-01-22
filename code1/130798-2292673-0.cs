    Public Class Repository: ObservableCollection<RepositoryItem>
    {
    }
    
    
    public class RepositoryItem
        {
            public string main {get; set};
            public string clean {get; set};
            public int curParCount {get; set};
            public int totalCount {get; set};
            public int parStart {get; set};
            public int partialStart {get; set};
            public double scrollPos {get; set};
            public int selectionStart {get; set};
            public int selectionEnd {get; set};
            public string[] status {get; };
        }     
