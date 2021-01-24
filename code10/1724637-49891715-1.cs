    public interface IDataProvider
    {
        void GetData();
    }
    public class ObjectA : IDataProvider
    {
        public ObjectA(int id)
        {
            this.Id = id;
        }
        public int Id
        {
            get;
        }
        public void GetData()
        {
            // Get A's data
        }
    }
    public class ObjectB : IDataProvider
    {
        public ObjectB(int id)
        {
            this.Id = id;
        }
        public int Id
        {
            get;
        }
        public void GetData()
        {
            // Get B's data
        }
    }
    public static class ObjectFactory
    {
        private static readonly Dictionary<string, Type> typeByNameDictionary = new Dictionary<string, Type>();
        static ObjectFactory()
        {
            typeByNameDictionary.Add("A", typeof(ObjectA));
            typeByNameDictionary.Add("B", typeof(ObjectB));            
        }
        public static bool TryGetObject<T>(string classTypePlusId, out T createdObject) where T : class 
        {
            string objectName = classTypePlusId.Substring(0, 1);
            if (!int.TryParse(classTypePlusId.Substring(1, 1), out int id))
            {
                throw new ArgumentOutOfRangeException(classTypePlusId, "something meaningful");
            }
            if (!typeByNameDictionary.TryGetValue(objectName, out Type objectType))
            {
                createdObject = default(T);
                return false;
            }
            createdObject = Activator.CreateInstance(objectType, id) as T;
            return createdObject != null;
        }
    }
    [TestFixture]
    public class Test
    {
        [Test]
        public void CanCreateObjects()
        {
            ObjectA a;
            ObjectB b;
            IDataProvider c;
            Assert.That(ObjectFactory.TryGetObject("A1", out a), Is.True);
            Assert.That(a.Id, Is.EqualTo(1));
            a.GetData();
            Assert.That(ObjectFactory.TryGetObject("A1", out b), Is.False);
            Assert.That(ObjectFactory.TryGetObject("B4", out b), Is.True);
            Assert.That(b.Id, Is.EqualTo(4));
            b.GetData();            
            Assert.That(ObjectFactory.TryGetObject("A2", out c), Is.True);
            c.GetData();
        }
    }
