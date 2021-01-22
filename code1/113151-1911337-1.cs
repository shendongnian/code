    public abstract class AbsCurveBased
    {
        internal Curve baseShape;
        double Area{get;set;}
    
        public AbsCurveBased(Curve baseShape)
        {
            this.baseShape = baseShape;
            //sets the Area property from the baseShape
        }
        protected AbsCurveBased(Curve baseShape, Action refreshFromBaseShape):
            this(baseShape)
        {
            refreshFromBaseShape();
        }
    }
    public class Shell : Extrusion
    {
        double ShellVolume{get;set;}
        double ShellThickness{get;set;}
    
        public Shell(Curve baseShape):
            base(baseShape, RefreshFromBaseShape)
        {
        }
        protected Shell(Curve baseShape, Action refreshFromBaseShape):
            this(baseShape)
        {
            refreshFromBaseShape();
        }
    
        private void RefreshFromBaseShape()
        {
            //sets this Shell Volume from the Extrusion properties and ShellThickness property
        }
    }
