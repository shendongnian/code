    public class SimpleEngine : Engine
    {
        private float _maxPower;
        public SimpleEngine(float maxPower)
        {
            _maxPower = maxPower;
        }
        
        internal override float MaxPower
        {
            get { return _maxPower; }            
        }
    }
