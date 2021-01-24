    public class SiloWrapper
    {
        public Silo Wrapped { get; }
        public Silo Parent { get; }
        private SiloWrapper(Silo silo, Silo parent)
        {
            this.Wrapped = silo;
            this.Parent = parent;
        }
        public IEnumerable<SiloWrapper> Map(IEnumerable<Silo> silos)
        {
            var dict = silos.ToDictionary((s) => s.Key);
            foreach(var s in silos)
            {
                yield return new SiloWrapped(s, s.ParentKey == null ? null : dict[s.ParentKey]);
            }
        }
    }
