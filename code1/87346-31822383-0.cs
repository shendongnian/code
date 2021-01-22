         [XmlIgnore]
                public string Content { get; set; }
    
       [XmlText]
                public XmlNode[] CDataContent
                {
                    get
                    {
                        var dummy = new XmlDocument();
                        return new XmlNode[] {dummy.CreateCDataSection(Content)};
                    }
                    set
                    {
                        if (value == null)
                        {
                            Content = null;
                            return;
                        }
    
                        if (value.Length != 1)
                        {
                            throw new InvalidOperationException(
                                String.Format(
                                    "Invalid array length {0}", value.Length));
                        }
    
                        var node0 = value[0];
                        var cdata = node0 as XmlCDataSection;
                        if (cdata == null)
                        {
                            throw new InvalidOperationException(
                                String.Format(
                                    "Invalid node type {0}", node0.NodeType));
                        }
    
                        Content = cdata.Data;
                    }
                }
            }
