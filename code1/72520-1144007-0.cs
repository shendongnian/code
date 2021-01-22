    public class Test1
        {
            public string Name { get; set; }
    
            public bool IsRegister { get; set; }
            public bool IsTransfert { get; set; }
            public bool IsSelfManaged { get; set; }
    
            public bool CanRegister { get { return true; } }
            public bool CanTransfert { get { return true; } }
            public bool CanSelfManage { get { return true; } }
        }
