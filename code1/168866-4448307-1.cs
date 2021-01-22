    using System.Configuration;
    /// <summary>
    /// Section for configuration known types for services.
    /// </summary>
    public class ServiceKnownTypesSection : ConfigurationSection
    {
        /// <summary>
        /// Gets services.
        /// </summary>
        [ConfigurationProperty("declaredServices", IsDefaultCollection = false)]
        [ConfigurationCollection(typeof(DeclaredServiceElement), AddItemName = "serviceContract", CollectionType = ConfigurationElementCollectionType.AddRemoveClearMap)]
        public DeclaredServiceElementCollection Services
        {
            get
            {
                return (DeclaredServiceElementCollection)base["declaredServices"];
            }
        }
    }
    /// <summary>
    /// Collection of declared service elements.
    /// </summary>
    public class DeclaredServiceElementCollection : ConfigurationElementCollection
    {
        /// <summary>
        /// Gets the service for which known types have been declared for.
        /// </summary>
        /// <param name="key">
        /// The key of the service.
        /// </param>
        public new DeclaredServiceElement this[string key]
        {
            get
            {
                return (DeclaredServiceElement)BaseGet(key);
            }
            set
            {
                var element = BaseGet(key);
                var index = this.BaseIndexOf(element);
                if (BaseGet(index) != null)
                {
                    BaseRemoveAt(index);
                }
                BaseAdd(index, value);
            }
        }
        /// <summary>
        /// When overridden in a derived class, creates a new <see cref="T:System.Configuration.ConfigurationElement"/>.
        /// </summary>
        /// <returns>
        /// A new <see cref="T:System.Configuration.ConfigurationElement"/>.
        /// </returns>
        protected override ConfigurationElement CreateNewElement()
        {
            return new DeclaredServiceElement();
        }
        /// <summary>
        /// Gets the element key for a specified configuration element when overridden in a derived class.
        /// </summary>
        /// <returns>
        /// An <see cref="T:System.Object"/> that acts as the key for the specified <see cref="T:System.Configuration.ConfigurationElement"/>.
        /// </returns>
        /// <param name="element">
        /// The <see cref="T:System.Configuration.ConfigurationElement"/> to return the key for. 
        /// </param>
        protected override object GetElementKey(ConfigurationElement element)
        {
            return ((DeclaredServiceElement)element).Type;
        }
    }
    /// <summary>
    /// The service for which known types are being declared for.
    /// </summary>
    public class DeclaredServiceElement : ConfigurationElement
    {
        /// <summary>
        /// Gets or sets Type.
        /// </summary>
        [ConfigurationProperty("type", IsRequired = true, IsKey = true)]
        public string Type
        {
            get
            {
                return (string) this["type"];
            }
            set
            {
                this["type"] = value;
            }
        }
        /// <summary>
        /// Gets KnownTypes.
        /// </summary>
        [ConfigurationProperty("knownTypes", IsDefaultCollection = false)]
        [ConfigurationCollection(typeof(DeclaredServiceElement), AddItemName = "knownType", CollectionType = ConfigurationElementCollectionType.AddRemoveClearMap)]
        public ServiceKnownTypeElementCollection KnownTypes
        {
            get
            {
                return (ServiceKnownTypeElementCollection)base["knownTypes"];
            }
        }
    }
    /// <summary>
    /// A collection of known type elements.
    /// </summary>
    public class ServiceKnownTypeElementCollection : ConfigurationElementCollection
    {
        /// <summary>
        /// Gets an known type with the specified key.
        /// </summary>
        /// <param name="key">
        /// The key of the known type.
        /// </param>
        public new ServiceKnownTypeElement this[string key]
        {
            get
            {
                return (ServiceKnownTypeElement)BaseGet(key);
            }
            set
            {
                var element = BaseGet(key);
                var index = this.BaseIndexOf(element);
                if (BaseGet(index) != null)
                {
                    BaseRemoveAt(index);
                }
                BaseAdd(index, value);
            }
        }
        /// <summary>
        /// When overridden in a derived class, creates a new <see cref="T:System.Configuration.ConfigurationElement"/>.
        /// </summary>
        /// <returns>
        /// A new <see cref="T:System.Configuration.ConfigurationElement"/>.
        /// </returns>
        protected override ConfigurationElement CreateNewElement()
        {
            return new ServiceKnownTypeElement();
        }
        /// <summary>
        /// Gets the element key for a specified configuration element when overridden in a derived class.
        /// </summary>
        /// <returns>
        /// An <see cref="T:System.Object"/> that acts as the key for the specified <see cref="T:System.Configuration.ConfigurationElement"/>.
        /// </returns>
        /// <param name="element">
        /// The <see cref="T:System.Configuration.ConfigurationElement"/> to return the key for. 
        /// </param>
        protected override object GetElementKey(ConfigurationElement element)
        {
            return ((ServiceKnownTypeElement)element).Type;
        }
    }
    /// <summary>
    /// Configuration element for a known type to associate with a service.
    /// </summary>
    public class ServiceKnownTypeElement : ConfigurationElement
    {
        /// <summary>
        /// Gets or sets TypeString.
        /// </summary>
        [ConfigurationProperty("type", IsRequired = true, IsKey = true)]
        public string TypeString
        {
            get
            {
                return (string)this["type"];
            }
            set
            {
                this["type"] = value;
            }
        }
        /// <summary>
        /// Gets or sets Type.
        /// </summary>
        public Type Type
        {
            get
            {
                return Type.GetType(this.TypeString);
            }
            set
            {
                this["type"] = value.AssemblyQualifiedName;
            }
        }
    }
