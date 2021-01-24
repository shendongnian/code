    public class ScriptTaskInfo
        {
            private TestClass GlobalTC;     
    
            public void Initialize(dynamic global_tc)
            {
                this.GlobalTC = global_tc; 
                this.GlobalTC.asd = "string set from script that should be visible in main code";
            }
    
            public void Execute()
            {
                //do something with this.GlobalTC
            }
        }
