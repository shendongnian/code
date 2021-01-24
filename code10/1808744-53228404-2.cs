    public static class GraphicPath : BaseSavedState
    {
        public List<int> PathX { get; private set; }
        public List<int> PathY { get; private set; }
    
        public GraphicPath(IParcelable superState)
            : base(superState)
        {
        }
    
        public GraphicPath(Parcel parcel) : base(parcel)
        {
            var size = parcel.ReadInt();
            int[] x = new int[size];
            int[] y = new int[size];
            parcel.ReadIntArray(x);
            parcel.ReadIntArray(y);
            PathX = new List<int>(x);
            PathY = new List<int>(y);
        }
    
        public override void WriteToParcel(Parcel dest, ParcelableWriteFlags flags)
        {
            base.WriteToParcel(dest, flags);
            dest.WriteInt(PathX.Count);
            dest.WriteIntArray(PathX.ToArray());
            dest.WriteIntArray(PathY.ToArray());
        }
    
        // creator stuff here
