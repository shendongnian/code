    public class Mob {
        // Constructors and stuff here
        public MoveBehavior Moving { set; get; }
        
        public void Move(long ticks) 
        {
            Moving.Move(ticks, this);
        }
    }
    public class MoveBehavior {
        protected int MovementRate { get; set; }
        public void Move(long ticks, Mob mob)
        {
            // logic moved over here now
        }
    }
