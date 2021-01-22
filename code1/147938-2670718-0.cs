    public class StrategyEditor : ...
    {
        public StrategyEditor()
        {
            InitializeComponent();
            if (numberOfLiveInstances >= maximumAllowedLiveInstances)
                throw ...;
            // not a nice solution IMHO, but if you've no other choice...
        }
    }
