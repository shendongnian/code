    public static class Position 
    {
        private PlayerPosition (string name, bool isDefensive ) {
            this.Name = name
            this.IsDefensive = isDefensive ;
        }
        // any properties you may need...
        public string Name { get; private set; }
        public bool IsDefensive { get; private set; }
        public bool IsOffensive { get { return !IsDefensive; } }
    
        // static instances that act like an enum
        public static readonly Quarterback = new PlayerPosition( "Quarterback", false );
        public static readonly Runningback = new PlayerPosition( "Runningback", false );
        public static readonly Linebacker = new PlayerPosition( "Linebacker", true );
        // etc...
    }
