    public class CompositeEngine : Engine
    {
        private List<Engine> _engines = new List<Engine>();
        public CompositeEngine(params Engine[] engines)
        {
            _engines.AddRange(engines);
        }
        internal override float MaxPower
        {
            get { return _engines.Sum(e => e.MaxPower); }             
        }
    }
