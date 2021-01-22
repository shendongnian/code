    public struct PhotonType {
        public static readonly PhotonType Default;
        
        public Color tint;
        
        static PhotonType() {
            // from here on out, PhotonType values initialized to PhotonType.Default
            // will have their tint set to Color.White
            Default = new PhotonType();
            Default.tint = Color.White;
        }
    }
