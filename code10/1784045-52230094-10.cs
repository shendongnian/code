    public abstract class ActionTaken : MonoBehaviour
    {
        public char Type { get; protected set; }
        public Transform Target { get; }
        // base ctor
        protected ActionTaken(Transform target)
        {
            Type = '\0'; 
            Target = target;
        }
        // Force implementation onto sub class
        public abstract void Activate();
    }
    public class MovementTaken : ActionTaken
    {
        public int TileH { get; set; }
        public int TileV { get; set; }
        public MovementTaken(Transform target, int tileH, int tileV)
            : base(target)
        {
            Type = 'M';
            TileH = tileH;
            TileV = tileV;
        }
        public override void Activate()
        {
            //some code using TileH and TileV
        }
    }
