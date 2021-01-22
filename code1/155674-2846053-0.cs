    public partial class Foo
    {
        public SqlGeography Location
        {
            get { return SqlGeography.STGeomFromWKB(LocationData, 4326); }
            set { LocationData = value.STAsBinary(); }
        }
    }
