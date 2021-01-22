    public class Bar
    {
        public event EventHandler PositionChanged;
    }
    public class Foo
    {
        private Dictionary<string, YourObject> m_objects;
        public Bar this[string id]
        {
            get
            {
                if (!m_object.ContainsKey(id))
                    m_object.Add(id, new Bar());
                return m_objects[id];
            }
        }
    }
