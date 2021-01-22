    class SpeedController {
        readonly SpeedControllers properties;
        public SpeedController(SpeedControllers properties) {
            this.properties = properties;
        }
        public int MaxSpeed {
            get {
                return properties.MaxSpeed;
            }
        }
     }
