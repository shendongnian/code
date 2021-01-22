    public abstract class BaseObject
    {
        public static int GetObjectSize<T>() where T : IPacket
        {
            ObjectAttribute[] attributes = (ObjectAttribute[])typeof(T).GetCustomAttributes(typeof(ObjectAttribute), false);
            return attributes.Length > 0 ? attributes[0].ObjectSize : 0;
        }
        public int ObjectSize 
        {
            get
            {
                ObjectAttribute[] attributes = (ObjectAttribute[])GetType().GetCustomAttributes(typeof(ObjectAttribute), false);
                return attributes.Length > 0 ? attributes[0].ObjectSize : 0;
            }
        }
    }
