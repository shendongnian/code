    [Serializable]
    [XmlInclude(typeof(MyRoot))]
    public abstract class RootElementBase<TEelment>
    {
        [XmlIgnore]
        public virtual List<TEelment> SubElements { get; set; }
        protected RootElementBase()
        {
            SubElements = new List<TEelment>();
        }
    }
