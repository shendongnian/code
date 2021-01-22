        /// <summary>
        ///A test sorting for SCCPackageEx Constructor
        ///</summary>
        [TestMethod()]
        public void SortingTest()
        {
            BaseSortedCollection<int> collection = new BaseSortedCollection<int>().AddItems(1,5,3,2,4,0);
            Assert.AreEqual(6, collection.Count, "collection.Count");
            for(int i=0; i <=5; i++)
               Assert.AreEqual(i, collection[i], "collection[" + i + "]");
        }
