    public class ObjectAttribute : Attribute
    {
        public int ObjectSize { get; set; }
        public ObjectAttribute(int objectSize)
        {
            this.ObjectSize = objectSize;
        }
    }
    public abstract class BaseObject
    {
        public static int GetObjectSize<T>() where T : IPacket
        {
            ObjectAttribute[] attributes = (ObjectAttribute[])typeof(T).GetCustomAttributes(typeof(ObjectAttribute), false);
            return attributes.Length > 0 ? attributes[0].ObjectSize : 0;
        }
    }
    [ObjectAttribute(15)]
    public class AObject : BaseObject
    {
        public string Code { get; set; }
        public int Height { get; set; }
    }
    [ObjectAttribute(25)]
    public class BObject : BaseObject
    {
        public string Code { get; set; }
        public int Weight { get; set; }
    }
