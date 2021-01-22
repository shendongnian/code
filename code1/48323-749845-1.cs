    public class Property
    {
        public string Name { get; set; }
        public string Value { get; set; }
    }
    public interface IPropertyBag { }
    public class PropertyBag : IPropertyBag
    {
        public Property[] Properties { get; set; }
    
        public Property this[string name]
        {
            get { return Properties.Where((e) => e.Name == name).Single(); }
            set { Properties.Where((e) => e.Name == name).Single().Value = value.Value; }
        }
    }
    
    [TestMethod]
    public void TestMethod1()
    {
        var pb = new PropertyBag() { Properties = new Property[] { new Property { Name = "X", Value = "Y" } } };
        Assert.AreEqual("Y", pb["X"].Value);
        pb["X"] = new Property { Name = "X", Value = "Z" };
        Assert.AreEqual("Z", pb["X"].Value);
    }
