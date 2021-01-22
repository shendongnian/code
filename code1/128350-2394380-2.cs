    public class Foo
    {
        public class Bar
        {
            public event EventHandler PositionChanged;
            internal void RaisePositionChanged()
            {
                var handler = PositionChanged;
                if (handler != null)
                    handler(this, EventArgs.Empty);
            }
        }
        private Dictionary<string, Bar> m_objects;
        public Bar this[string id]
        {
            get
            {
                if (!m_objects.ContainsKey(id))
                    m_objects.Add(id, new Bar());
                return m_objects[id];
            }
        }
        private void RaisePositionChanged(string id)
        {
            Bar bar;
            if (m_objects.TryGetValue(id, out bar))
                bar.RaisePositionChanged();
        }
    }
