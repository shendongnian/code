        class ReplCommand
        {
    
            public string Command { get; set; }
            public string HelpText { get; set; }
            public Action<string> MethodToCall { get; set; }
            public int HelpSortOrder { get; set; }
    
        }
