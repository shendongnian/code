      public class CollisionBase
        {
            public CollisionBase(Body body, GameObject entity)
            {
                
            }
        }
    
        public class TerrainCollision : CollisionBase
        {
            public TerrainCollision(Body body, GameObject entity)
                : base(body, entity)
            {
                
            }
        }
