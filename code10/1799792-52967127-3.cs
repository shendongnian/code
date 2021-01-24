    [TestFixture]
    public class PartitionTests
    {
        public class Node
        {
            private List<Node> subNodes = new List<Node>();
            public Node(string name)
            {
                this.Name = name;
            }
            public IEnumerable<Node> DependentNodes { get { return this.subNodes; } }
            public string Name { get; }
            internal void AddDependentNode(Node subNode)
            {
                subNodes.Add(subNode);
            }
            public override string ToString()
            {
                //just to make debugging easier in this example
                return this.Name;
            }
        }
        [Test]
        public void PartitionTest1()
        {
            #region prepare
            Node A = new Node("A");
            Node B = new Node("B");
            Node C = new Node("C");
            Node D = new Node("D");
            Node E = new Node("E");
            Node F = new Node("F");
            A.AddDependentNode(B);
            B.AddDependentNode(C);
            D.AddDependentNode(C);
            E.AddDependentNode(F);
            var allNodes = new List<Node>() { A, B, C, D, E, F };
            #endregion
            #region Implementation
            var buckets = new List<List<Node>>();
            foreach (var n in allNodes)
            {
                var existingBucket = buckets.FirstOrDefault(b => b.Contains(n));
                if (existingBucket == null)
                {
                    existingBucket = new List<Node>() { n };
                }
                foreach (var dependentNode in n.DependentNodes)
                {
                    var otherBucket = buckets.FirstOrDefault(b => b.Contains(dependentNode));
                    if (otherBucket == null)
                    {
                        existingBucket.Add(dependentNode);
                    }
                    else
                    {
                        existingBucket.Remove(n);
                        otherBucket.Add(n);
                        foreach (var alreadyPlacedNode in existingBucket)
                        {
                            existingBucket.Remove(alreadyPlacedNode);
                            if (!otherBucket.Contains(alreadyPlacedNode))
                            {
                                otherBucket.Add(alreadyPlacedNode);
                            }
                        }
                    }
                }
                if (!buckets.Contains(existingBucket) && existingBucket.Any())
                {
                    buckets.Add(existingBucket);
                }
            }
            #endregion
            #region test
            Assert.AreEqual(2, buckets.Count, "Expect two buckets");
            Assert.AreEqual(4, buckets[0].Count);  //we should not rely on the order of buckets here
            Assert.AreEqual(2, buckets[1].Count);
            CollectionAssert.Contains(buckets[0], A);
            CollectionAssert.Contains(buckets[0], B);
            CollectionAssert.Contains(buckets[0], C);
            CollectionAssert.Contains(buckets[0], D);
            CollectionAssert.Contains(buckets[1], E);
            CollectionAssert.Contains(buckets[1], F);
            #endregion
        }
    }
