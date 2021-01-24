    [Flags]
    public enum RequestedEffect {
        None = 0,
        Mix = 1,
        Blur = 2,
        DanceLightFandango = 4
    }
    
    public struct Effects {
        public RequestedEffect Effect;
        public EffectAnimation BlurEffect;
        public EffectAnimation MixEffect;
        public EffectAnimation DanceLightFanangoEffect;
    }
