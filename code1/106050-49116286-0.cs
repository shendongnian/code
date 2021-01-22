    //move this line to a new physical file:
    public delegate void LocationSearchedEventHandler( object sender );
    
    public partial class controls_Drives_LocationAddPanel : UserControl
    {
        public event LocationAddedEventHandler LocationAdded;
        protected virtual void OnLocationAdded(LocationAddEventArg e)
        {
