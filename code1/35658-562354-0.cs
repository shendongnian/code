    public class Foo1
    {
        public struct Bar
        {
            string A;
            string B;
        }
        private Bar[] data;
        // Using a method
        public Bar[] ExportData()
        {
            return data;
        }
        // Using properties
        public Bar[] DataProperty
        {
            get { return data; }
        }
    }
    public class Foo2
    {
        private Foo1.Bar[] data;
        // Using a method
        public void ImportData(Foo1 source)
        {
            this.data = source.ExportData();
        }
        // Using properties
        public Foo1.Bar[] DataProperty
        {
            get { return data; }
        }
        public void ReadProperty(Foo1 source)
        {
            this.DataProperty = source.DataProperty;
        }
    }
