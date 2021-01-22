    public class MoineauFlankContours
    {
        public MoineauFlankContour Rotor { get; private set; }
        public MoineauFlankContour Stator { get; private set; }
         public MoineauFlankContours()
        {
            _RoIndexer = Indexer.Create(( MoineauPartEnum p ) => 
                p == MoineauPartEnum.Rotor ? Rotor : Stator);
        }
        private RoIndexer<MoineauPartEnum, MoineauFlankContour> _RoIndexer;
        
        public RoIndexer<MoineauPartEnum, MoineauFlankContour> FlankFor
        {
            get
            {
                return _RoIndexer;
            }
        }
    }
    
