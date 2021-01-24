    public class MyObject
    {
        public int Id { get; set; }
        public bool Flag { get; set; }
        public static MyObject GetEntityClone(MyObject obj)
        {
            if (obj == null) return null;
            var newObj = new MyObject()
            {
                Id = obj.Id,
                Flag = obj.Flag
            };
            return newObj;
        }
    }
