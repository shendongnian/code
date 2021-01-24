    public partial class hashTree {
        [XmlIgnore]
        public hashTree HashTree {
            get {
                if (hashTree1 != null) {
                    return hashTree1[0] as hashTree;
                } else {
                    return null;
                }
            }
        }
        [XmlIgnore]
        public hashTreeThreadGroup ThreadGroupItem {
            get {
                if (ThreadGroup != null) {
                    var threadGroup = ThreadGroup[0]; // as hashTreeThreadGroup;
                    PropertyGrouper.GroupProperties(threadGroup);
                    return threadGroup;
                } else {
                    return null;
                }
            }
        }
        [XmlIgnore]
        public hashTreeHTTPSamplerProxy HttpSamplerProxyItem {
            get {
                if (HTTPSamplerProxy != null) {
                    var httpSamplerProxy = HTTPSamplerProxy[0];
                    PropertyGrouper.GroupProperties(httpSamplerProxy);
                    return httpSamplerProxy;
                } else {
                    return null;
                }
            }
        }
    }
