    public class ClassWithEventAndField
    {
        public event EventHandler MyEvent;
        public int MyField;
    }
    
    [Test]
    public void TestFieldsFilter()
    {
        IEnumerable<FieldInfo> fields = 
            FilterBackingEventFields(typeof(ClassWithEventAndField));
    
        FieldInfo expectedField = typeof(ClassWithEventAndField).GetField("MyField");
        Assert.That(fields, Is.EquivalentTo(new[] { expectedField }));
    }
