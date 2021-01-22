    public struct SpeedControllers {
        int speed;
        int etc;
        
        public SpeedControllers(int s, int e) {
            speed = s;
            etc = e;
        }
        
        public const SpeedControllers TRAXXAS_XL5 = new SpeedControllers(123, 345);
        public const SpeedControllers WHATEVER = new SpeedControllers(456, 789);
    }
