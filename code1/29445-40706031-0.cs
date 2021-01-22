    public void TestMethod1()
        {
            var expected = new List<DotaViewer.Interface.DotaHero>();
            for (int i = 0; i < 22; i++)//You add empty initialization here
            {
                var temp = new DotaViewer.Interface.DotaHero();
                expected.Add(temp);
            }
            var nw = new DotaHeroCsvService();
            var items = nw.GetHero();
            CollectionAssert.AreEqual(expected,items);
            
        }
