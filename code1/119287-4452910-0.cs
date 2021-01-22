    public partial class MainView : UserControl
    {
        public MainView( ) 
        {
            InitializeComponent( );
            ObservableObject<IRegion> observableRegion = RegionManager.GetObservableRegion( ContentHost );
            observableRegion.PropertyChanged += ( sender, args ) =>
            {
                IRegion region = ( (ObservableObject<IRegion>)sender ).Value;
                region.SortComparison = CompareViews;
            };
        }
        private static int CompareViews( object x, object y )
        {
            IPositionView positionX = x as IPositionView;
            IPositionView positionY = y as IPositionView;
            if ( positionX != null && positionY != null )
            {
                //Position is a freely choosable integer
                return Comparer<int>.Default.Compare( positionX.Position, positionY.Position );
            }
            else if ( positionX != null )
            {
                //x is a PositionView, so we favour it here
                return -1;
            }
            else if ( positionY != null )
            {
                //y is a PositionView, so we favour it here
                return 1;
            }
            else
            {
                //both are no PositionViews, so we use string comparison here
                return String.Compare( x.ToString( ), y.ToString( ) );
            }
        }
    }
