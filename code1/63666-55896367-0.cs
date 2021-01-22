    class TreeViewRecord:TreeNode
        {
            private object DataBoundObject { get; set; }
            public TreeViewRecord(string value,object dataBoundObject)
            {
                if (dataBoundObject != null) DataBoundObject = dataBoundObject;
                Text = value;
                Name = value;
                DataBoundObject = dataBoundObject;
            }
            public TreeViewRecord()
            {
            }
            
            public object GetDataboundObject()
            {
                return DataBoundObject;
            }
        }
