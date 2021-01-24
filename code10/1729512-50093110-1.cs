    public abstract class LineContainer<T> where T : LineContainer<T>
    {
        public abstract IEnumerable<Line3d> Get3dLines();
    
        public abstract bool CanBeGroupedWith(T container);
    }
    
    public class DimensionContainer : LineContainer<DimensionContainer>
    {     
        public override IEnumerable<Line3d> Get3dLines()
        {       
        }
    
        public override bool CanBeGroupedWith(DimensionContainer container)
        {
        }
    }
