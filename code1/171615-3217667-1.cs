    using System.Xml.Serialization;
    
    
    
    
    /// <remarks/>
    [System.CodeDom.Compiler.GeneratedCodeAttribute("xsd", "2.0.50727.3038")]
    [System.SerializableAttribute()]
    [System.Diagnostics.DebuggerStepThroughAttribute()]
    [System.ComponentModel.DesignerCategoryAttribute("code")]
    [System.Xml.Serialization.XmlTypeAttribute(AnonymousType=true, Namespace="http://tempuri.org/AnimalComments.xsd")]
    [System.Xml.Serialization.XmlRootAttribute(Namespace="http://tempuri.org/AnimalComments.xsd", IsNullable=false)]
    public partial class Animals {
        
        private Animal[] animalField;
        
        /// <remarks/>
        [System.Xml.Serialization.XmlElementAttribute("Animal")]
        public Animal[] Animal {
            get {
                return this.animalField;
            }
            set {
                this.animalField = value;
            }
        }
    }
    
    /// <remarks/>
    [System.CodeDom.Compiler.GeneratedCodeAttribute("xsd", "2.0.50727.3038")]
    [System.SerializableAttribute()]
    [System.Diagnostics.DebuggerStepThroughAttribute()]
    [System.ComponentModel.DesignerCategoryAttribute("code")]
    [System.Xml.Serialization.XmlTypeAttribute(AnonymousType=true, Namespace="http://tempuri.org/AnimalComments.xsd")]
    [System.Xml.Serialization.XmlRootAttribute(Namespace="http://tempuri.org/AnimalComments.xsd", IsNullable=false)]
    public partial class Animal {
        
        private Comments commentsField;
        
        private int idField;
        
        private bool idFieldSpecified;
        
        /// <remarks/>
        public Comments Comments {
            get {
                return this.commentsField;
            }
            set {
                this.commentsField = value;
            }
        }
        
        /// <remarks/>
        [System.Xml.Serialization.XmlAttributeAttribute()]
        public int ID {
            get {
                return this.idField;
            }
            set {
                this.idField = value;
            }
        }
        
        /// <remarks/>
        [System.Xml.Serialization.XmlIgnoreAttribute()]
        public bool IDSpecified {
            get {
                return this.idFieldSpecified;
            }
            set {
                this.idFieldSpecified = value;
            }
        }
    }
    
    /// <remarks/>
    [System.CodeDom.Compiler.GeneratedCodeAttribute("xsd", "2.0.50727.3038")]
    [System.SerializableAttribute()]
    [System.Diagnostics.DebuggerStepThroughAttribute()]
    [System.ComponentModel.DesignerCategoryAttribute("code")]
    [System.Xml.Serialization.XmlTypeAttribute(AnonymousType=true, Namespace="http://tempuri.org/AnimalComments.xsd")]
    [System.Xml.Serialization.XmlRootAttribute(Namespace="http://tempuri.org/AnimalComments.xsd", IsNullable=false)]
    public partial class Comments {
        
        private Comment[] commentField;
        
        /// <remarks/>
        [System.Xml.Serialization.XmlElementAttribute("Comment")]
        public Comment[] Comment {
            get {
                return this.commentField;
            }
            set {
                this.commentField = value;
            }
        }
    }
    
    /// <remarks/>
    [System.CodeDom.Compiler.GeneratedCodeAttribute("xsd", "2.0.50727.3038")]
    [System.SerializableAttribute()]
    [System.Diagnostics.DebuggerStepThroughAttribute()]
    [System.ComponentModel.DesignerCategoryAttribute("code")]
    [System.Xml.Serialization.XmlTypeAttribute(AnonymousType=true, Namespace="http://tempuri.org/AnimalComments.xsd")]
    [System.Xml.Serialization.XmlRootAttribute(Namespace="http://tempuri.org/AnimalComments.xsd", IsNullable=false)]
    public partial class Comment {
        
        private string contentField;
        
        private int commentIDField;
        
        private bool commentIDFieldSpecified;
        
        /// <remarks/>
        public string Content {
            get {
                return this.contentField;
            }
            set {
                this.contentField = value;
            }
        }
        
        /// <remarks/>
        [System.Xml.Serialization.XmlAttributeAttribute()]
        public int CommentID {
            get {
                return this.commentIDField;
            }
            set {
                this.commentIDField = value;
            }
        }
        
        /// <remarks/>
        [System.Xml.Serialization.XmlIgnoreAttribute()]
        public bool CommentIDSpecified {
            get {
                return this.commentIDFieldSpecified;
            }
            set {
                this.commentIDFieldSpecified = value;
            }
        }
    }
