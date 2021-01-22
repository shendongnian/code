    public class ProcessBlock
        {
            private List<ProcessProperties> _propList;
            public List<ProcessProperties> propList(){get{return _propList;}}
            public ProcessBlock(List<ProcessProperties> properties)
            { _propList = properties; }
        }
