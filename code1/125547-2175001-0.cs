    struct Tribool {
        enum TriboolState { Unknown = 0, True = 1, False = 2 }
        private readonly TriboolState state;
        public Tribool(bool state) {
            this.state = state ? TriboolState.True : TriboolState.False;
        }
        // default struct ctor handles unknown
    }
