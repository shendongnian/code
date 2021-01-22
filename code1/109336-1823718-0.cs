    /// <summary>
    /// The data storage could look something like this
    /// create table PersistedObject (ObjectId int )
    /// create table PersistedProperty (PropertyId int , PropertyName varchar(50) )
    /// create table Data (ValueId int, PropertyId int, SerializedValue image )
    /// </summary>
    interface IFlexiblePersistence
    {
        object this[string propertyName] { get; set;}
        void Persist();
    }
    class Person : IFlexiblePersistence
    {
        Dictionary<string, object> data;
        public Person(int personId)
        {
            data = PopulatePersonData(personId);
        }
        public object this[string propertyName]
        {
            get { return data[propertyName]; }
            set
            {
                data[propertyName] = value;
                Persist();
            }
        }
        public void Persist()
        {
            LoopThroughAllValuesAndSaveToDB();
        }
    }
