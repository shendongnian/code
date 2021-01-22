    private static bool _running = false;
        /// <summary>
        /// Gets or sets a value indicating whether this <see cref="Program"/> is running.
        /// This property is used for design time WSOD issues and is used instead of the 
        /// DesignMode property of a control as the DesignMode property has been said to be
        /// unreliable.
        /// </summary>
        /// <value><c>true</c> if running; otherwise, <c>false</c>.</value>
        public static bool Running
        {
            get
            {
                return _running;
            }
        }
        static void Main(string[] args)
        {
            Initialize();
                      
            _running = true;
