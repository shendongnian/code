    public class MoineauFlankContours
    {
        public MoineauFlankContour Rotor { get; private set; }
        public MoineauFlankContour Stator { get; private set; }
        /// Enable indexing of the Rotor or Stator using an enum to 
        /// select the desired element.
        public RoIndexer<MoineauPartEnum, MoineauFlankContour> FlankFor
        {
            get
            {
                return Indexer.Create(
                	(MoineauPartEnum p) => p == MoineauPartEnum.Rotor 
                	                       ? Rotor : Stator);
            }
        }
    }
    
