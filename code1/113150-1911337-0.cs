    public abstract class AbsCurveBased
    {
        internal Curve baseShape;
        double Area{get;set;}
    
        public AbsCurveBased(Curve baseShape)
        {
            this.baseShape = baseShape;
            RefreshFromBaseShape();
        }
    
        public void RefreshFromBaseShape()
        {
            //sets the Area property from the baseShape
            ...
            // call child handlers
            var handler = RefreshingFromBaseShape;
            if (handler != null)
                handler();
        }
        protected event Action RefreshingFromBaseShape;
    }
    public class Shell : Extrusion
    {
        double ShellVolume{get;set;}
        double ShellThickness{get;set;}
    
        public Shell(Curve baseShape): base(baseShape)
        {
            this.RefreshingFromBaseShape += RefreshingFromBaseShapeHandler;
            this.baseShape = baseShape;
            RefreshFromBaseShape();
        }
    
        private void RefreshingFromBaseShapeHandler()
        {
            //sets this Shell Volume from the Extrusion properties and ShellThickness property
        }
    }
