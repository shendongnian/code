    public class SidePosition
    {
        public IdInfo IdInfo;
    
        public SidePosition DeepCopy()
        {
           SidePosition other = (SidePosition) this.MemberwiseClone();
           other.IdInfo= new IdInfo(IdInfo.IdNumber);
           return other;
        }
    }
    
    public class Side
    {
        public IdInfo IdInfo;
    
        public Side DeepCopy()
        {
           Side other = (Side) this.MemberwiseClone();
           other.IdInfo= new IdInfo(IdInfo.IdNumber);
           return other;
        }
    }
    
    public Cube Right(Cube cube) {
            Dictionary<SidePosition, Side> newSides = new Dictionary<SidePosition, Side>();
            foreach(var item in cube.Sides)
               newSides.Add(new SidePosition(item.key), new Side(item.value));
    
            //your logic
        }
