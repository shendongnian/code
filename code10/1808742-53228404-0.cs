    public class GraphicPathCreator : Java.Lang.Object, IParacleableCreator
    {
        public Java.Lang.Object CreateFromParcel(Parcel source)
        {
            return new GraphicPath(source);
        }
    
        public Java.Lang.Object[] NewArray(int size)
        {
            return new GraphicPath[size];
        }
    }
