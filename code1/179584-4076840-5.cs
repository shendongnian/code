    class TestEntity
    {
        public Node Root {get; set;}
    }
    class Node
    {
        public string Leaf {get; set;}
    }
    class TestFlattenedEntity
    {
        public string RootLeaf {get; set;}
    }
    string result = ConcatenatedPropertyNameResolver.GetOriginatingPropertyName<TestEntity, TestFlattenedEntity>("RootLeaf");
    Assert.AreEqual("Root.Leaf", result);
