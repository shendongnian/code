    public class UserElement : ConfigurationElement
    {
        [ConfigurationProperty( "firstName", IsRequired = true )]
        public string FirstName
        {
            get { return (string) base[ "firstName" ]; }
            set { base[ "firstName" ] = value;}
        }
        [ConfigurationProperty( "lastName", IsRequired = true )]
        public string LastName
        {
            get { return (string) base[ "lastName" ]; }
            set { base[ "lastName" ] = value; }
        }
        [ConfigurationProperty( "email", IsRequired = true )]
        public string Email
        {
            get { return (string) base[ "email" ]; }
            set { base[ "email" ] = value; }
        }
        internal string Key
        {
            get { return string.Format( "{0}|{1}|{2}", FirstName, LastName, Email ); }
        }
    }
    [ConfigurationCollection( typeof(UserElement), AddItemName = "user", CollectionType = ConfigurationElementCollectionType.BasicMap )]
    public class UserElementCollection : ConfigurationElementCollection
    {
        protected override ConfigurationElement CreateNewElement()
        {
            return new UserElement();
        }
        protected override object GetElementKey( ConfigurationElement element )
        {
            return ( (UserElement) element ).Key;
        }
        public void Add( UserElement element )
        {
            BaseAdd( element );
        }
        public void Clear()
        {
            BaseClear();
        }
        public int IndexOf( UserElement element )
        {
            return BaseIndexOf( element );
        }
        public void Remove( UserElement element )
        {
            if( BaseIndexOf( element ) >= 0 )
            {
                BaseRemove( element.Key );
            }
        }
        public void RemoveAt( int index )
        {
            BaseRemoveAt( index );
        }
        public UserElement this[ int index ]
        {
            get { return (UserElement) BaseGet( index ); }
            set
            {
                if( BaseGet( index ) != null )
                {
                    BaseRemoveAt( index );
                }
                BaseAdd( index, value );
            }
        }
    }
    public class UserInfoSection : ConfigurationSection
    {
        private static readonly ConfigurationProperty _propUserInfo = new ConfigurationProperty(
                null,
                typeof(UserElementCollection),
                null,
                ConfigurationPropertyOptions.IsDefaultCollection
        );
        private static ConfigurationPropertyCollection _properties = new ConfigurationPropertyCollection();
        static UserInfoSection()
        {
            _properties.Add( _propUserInfo );
        }
        [ConfigurationProperty( "", Options = ConfigurationPropertyOptions.IsDefaultCollection )]
        public UserElementCollection Users
        {
            get { return (UserElementCollection) base[ _propUserInfo ]; }
        }
    }
