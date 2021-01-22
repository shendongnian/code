    /// <summary>
    /// A simple data transfer entity
    /// </summary>
    public struct name_data
    {
        public long name_id;
        public string name;
        public string description;
        public name_data(long id, string n, string d)
        {
            name_id = id;
            name = n;
            description = d;
        }
    }
