    public interface IResources
    {
        Resource GetResource();
    }
    public partial class ResourceA : IResources
    {
        public Resource GetResource()
        {
            return new Resource()
            {
                ID = ID,
                ProductID = ProductID
            };
        }
    }
    public partial class ResourceB : IResources
    {
        public Resource GetResource()
        {
            return new Resource()
            {
                ID = ID,
                ProductID = ProductID
            };
        }
    }
    public partial class ResourceC : IResources
    {
        public Resource GetResource()
        {
            return new Resource()
            {
                ID = ID,
                ProductID = ProductID
            };
        }
    }
    public class Resource
    {
        public int ID { get; set; }
        public long ProductID { get; set; }
    }
    //These are the "generated" EF partials
    public partial class ResourceA
    {
        public int ID { get; set; }
        public long ProductID { get; set; }
        public string Path { get; set; }
    }
    public partial class ResourceB
    {
        public int ID { get; set; }
        public long ProductID { get; set; }
        public string Label { get; set; }
    }
    public partial class ResourceC
    {
        public int ID { get; set; }
        public long ProductID { get; set; }
        public bool Open { get; set; }
        public bool Replacement { get; set; }
    }
