    using System;
    using System.Diagnostics;
    using System.IO;
    using System.Runtime.Serialization;
    using System.Runtime.Serialization.Formatters.Binary;
    public interface ILink
    {
        int Linkid { get; set; }
        bool IsActive { get; set; }
    }
    [Serializable]
    public class Domain : AbstractLink
    {
        public Domain()
        {
        }
        public Domain(SerializationInfo info, StreamingContext ctx) 
            : base(info, ctx)
        {
        }
    }
    [Serializable]
    public class User : AbstractLink
    {
        public string UserName { get; set; }
        public User()
        {
        }
        public User(SerializationInfo info, StreamingContext ctx) 
            : base(info, ctx)
        {
            UserName = info.GetString("UserName");
        }
        public override void GetObjectData(SerializationInfo info, StreamingContext ctx)
        {
            base.GetObjectData(info, ctx);
            info.AddValue("UserName", UserName);
        }
    }
    public abstract class AbstractLink : ISerializable, ILink, IEquatable<ILink>
    {
        public AbstractLink() { }
        public AbstractLink(SerializationInfo info, StreamingContext ctx)
        {
            Linkid = info.GetInt32("Linkid");
            IsActive = info.GetBoolean("IsActive");
        }
        public virtual void GetObjectData(SerializationInfo info, StreamingContext ctx)
        {
            info.AddValue("Linkid", Linkid);
            info.AddValue("IsActive", IsActive);
        }
        public bool Equals(ILink other)
        {
            if (ReferenceEquals(null, other))
                return false;
            
            if (ReferenceEquals(this, other))
                return true;
            
            return other.Linkid == Linkid && other.IsActive.Equals(IsActive);
        }
        public override bool Equals(object obj)
        {
            if (ReferenceEquals(null, obj))
                return false;
            if (ReferenceEquals(this, obj))
                return true;
            return obj.GetType() == typeof(AbstractLink) && Equals((AbstractLink) obj);
        }
        public override int GetHashCode()
        {
            unchecked
            {
                return (Linkid * 397) ^ IsActive.GetHashCode();
            }
        }
        public int Linkid { get; set; }
        public bool IsActive { get; set; }
    }
    class Program
    {
        static void Main(string[] args)
        {
            var user = new User { UserName = "user", IsActive = true, Linkid = 1 };
            User user2;
           
            using (var ms = new MemoryStream())
            {
                var bf = new BinaryFormatter();
                bf.Serialize(ms, user);
                ms.Flush();
                
                ms.Seek(0, SeekOrigin.Begin);
                user2 = bf.Deserialize(ms) as User;
            }
            Debug.Assert(user2 != null);
            Debug.Assert(ReferenceEquals(user, user2) == false);
            Debug.Assert(Equals(user.Linkid, user2.Linkid));
            Debug.Assert(Equals(user.IsActive, user2.IsActive));
            Debug.Assert(Equals(user.UserName, user2.UserName));
        }
    }
