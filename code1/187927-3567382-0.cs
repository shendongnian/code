    [System.CodeDom.Compiler.GeneratedCodeAttribute("xsd", "2.0.50727.3038")]
    [System.SerializableAttribute()]
    [System.Diagnostics.DebuggerStepThroughAttribute()]
    [System.ComponentModel.DesignerCategoryAttribute("code")]
    [System.Xml.Serialization.XmlTypeAttribute(AnonymousType=true)]
    [System.Xml.Serialization.XmlRootAttribute(Namespace="", IsNullable=false)]
    public partial class SalesOrder {
        
        private OrderHeader orderHeaderField;
        
        private LineItemList lineItemListField;
        
        /// <remarks/>
        public OrderHeader OrderHeader {
            get {
                return this.orderHeaderField;
            }
            set {
                this.orderHeaderField = value;
            }
        }
        
        /// <remarks/>
        public LineItemList LineItemList {
            get {
                return this.lineItemListField;
            }
            set {
                this.lineItemListField = value;
            }
        }
    }
    
    /// <remarks/>
    [System.CodeDom.Compiler.GeneratedCodeAttribute("xsd", "2.0.50727.3038")]
    [System.SerializableAttribute()]
    [System.Diagnostics.DebuggerStepThroughAttribute()]
    [System.ComponentModel.DesignerCategoryAttribute("code")]
    [System.Xml.Serialization.XmlTypeAttribute(AnonymousType=true)]
    [System.Xml.Serialization.XmlRootAttribute(Namespace="", IsNullable=false)]
    public partial class OrderHeader {
        
        private BillTo billToField;
        
        /// <remarks/>
        public BillTo BillTo {
            get {
                return this.billToField;
            }
            set {
                this.billToField = value;
            }
        }
    }
    
    /// <remarks/>
    [System.CodeDom.Compiler.GeneratedCodeAttribute("xsd", "2.0.50727.3038")]
    [System.SerializableAttribute()]
    [System.Diagnostics.DebuggerStepThroughAttribute()]
    [System.ComponentModel.DesignerCategoryAttribute("code")]
    [System.Xml.Serialization.XmlTypeAttribute(AnonymousType=true)]
    [System.Xml.Serialization.XmlRootAttribute(Namespace="", IsNullable=false)]
    public partial class BillTo {
        
        private short entityIDField;
        
        /// <remarks/>
        public short EntityID {
            get {
                return this.entityIDField;
            }
            set {
                this.entityIDField = value;
            }
        }
    }
    
    /// <remarks/>
    [System.CodeDom.Compiler.GeneratedCodeAttribute("xsd", "2.0.50727.3038")]
    [System.SerializableAttribute()]
    [System.Diagnostics.DebuggerStepThroughAttribute()]
    [System.ComponentModel.DesignerCategoryAttribute("code")]
    [System.Xml.Serialization.XmlTypeAttribute(AnonymousType=true)]
    [System.Xml.Serialization.XmlRootAttribute(Namespace="", IsNullable=false)]
    public partial class LineItemList {
        
        private OrderLineComment orderLineCommentField;
        
        private string[] lineItemField;
        
        /// <remarks/>
        public OrderLineComment OrderLineComment {
            get {
                return this.orderLineCommentField;
            }
            set {
                this.orderLineCommentField = value;
            }
        }
        
        /// <remarks/>
        [System.Xml.Serialization.XmlElementAttribute("LineItem")]
        public string[] LineItem {
            get {
                return this.lineItemField;
            }
            set {
                this.lineItemField = value;
            }
        }
    }
    
    /// <remarks/>
    [System.CodeDom.Compiler.GeneratedCodeAttribute("xsd", "2.0.50727.3038")]
    [System.SerializableAttribute()]
    [System.Diagnostics.DebuggerStepThroughAttribute()]
    [System.ComponentModel.DesignerCategoryAttribute("code")]
    [System.Xml.Serialization.XmlTypeAttribute(AnonymousType=true)]
    [System.Xml.Serialization.XmlRootAttribute(Namespace="", IsNullable=false)]
    public partial class OrderLineComment {
        
        private sbyte lineItemIDField;
        
        /// <remarks/>
        public sbyte LineItemID {
            get {
                return this.lineItemIDField;
            }
            set {
                this.lineItemIDField = value;
            }
        }
    }
