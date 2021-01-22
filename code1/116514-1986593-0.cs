    class ServiceResponseSection : ConfigurationSection
    {
        [ConfigurationProperty("ServiceResponses")]
        [ConfigurationCollection(typeof(ServiceResponse), AddItemName = "addServiceResponse", RemoveItemName = "removeServiceResponse", ClearItemsName = "clearServiceResponses")]
        public ServiceResponses ServiceResponses
        {
            get { return this["ServiceResponses"] as ServiceResponses; }
        }
    }
    public class ServiceResponses : ConfigurationElementCollection
    {
        public override ConfigurationElementCollectionType CollectionType
        {
            get
            {
                return ConfigurationElementCollectionType.AddRemoveClearMap;
            }
        }
        public ServiceResponse this[int index]
        {
            get
            {
                return (ServiceResponse)this.BaseGet(index);
            }
            set
            {
                if (this.BaseGet(index) != null)
                {
                    this.BaseRemoveAt(index);
                }
                this.BaseAdd(index, value);
            }
        }
        public new ServiceResponse this[string responseString]
        {
            get
            {
                return (ServiceResponse)this.BaseGet(responseString);
            }
            set
            {
                if (this.BaseGet(responseString) != null)
                {
                    this.BaseRemoveAt(this.BaseIndexOf(this.BaseGet(responseString)));
                }
                this.BaseAdd(value);
            }
        }
        public void Add(ServiceResponse ServiceResponse)
        {
            this.BaseAdd(ServiceResponse);
        }
        public void Clear()
        {
            this.BaseClear();
        }
        protected override ConfigurationElement CreateNewElement()
        {
            return new ServiceResponse();
        }
        protected override object GetElementKey(ConfigurationElement element)
        {
            return ((ServiceResponse)element).ResponseString;
        }
        public void Remove(ServiceResponse element)
        {
            BaseRemove(element.ResponseString);
        }
        public void Remove(string responseString)
        {
            BaseRemove(responseString);
        }
        public void RemoveAt(int index)
        {
            BaseRemoveAt(index);
        }
    }
    public class ServiceResponse : ConfigurationElement
    {
        private int m_tryCount;
        public ServiceResponse()
        {
            this.m_tryCount = 0;
        }
        [ConfigurationProperty("responseString")]
        public string ResponseString
        {
            get { return (String)this["responseString"]; }
            set { this["responseString"] = value; }
        }
        [ConfigurationProperty("matchWholeString")]
        public bool MatchWholeString
        {
            get
            {
                return (bool)this["matchWholeString"];
            }
            set
            {
                this["matchWholeString"] = value.ToString();
            }
        }
        [ConfigurationProperty("retryCount")]
        public int RetryCount
        {
            get
            {
                return (int)this["retryCount"];
            }
            set
            {
                this["retryCount"] = value.ToString();
            }
        }
        [ConfigurationProperty("failsProcess")]
        public bool FailsProcess
        {
            get
            {
                return (bool)this["failsProcess"];
            }
            set
            {
                this["failsProcess"] = value.ToString();
            }
        }
        public int TryCount
        {
            get { return this.m_tryCount; }
            set { this.m_tryCount = value; }
        }
        public void Reset()
        {
            this.m_tryCount = 0;
        }
        
    }
