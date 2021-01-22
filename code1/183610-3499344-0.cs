    abstract class SpeedControllers {
        public abstract int MaxSpeed { get; }
        public class TRAXXAS_XL5 : SpeedControllers{
            public override int MaxSpeed {
                get {
                    return 30;
                }
            }
        }
    }
