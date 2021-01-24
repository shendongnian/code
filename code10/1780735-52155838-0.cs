        [TestMethod]
        public void ICanSeeWhenInnerAndOuterCollectionsAreSubsets()
        {
            HashSet<int> firstInnerIds = new HashSet<int>(GetFirstOuterList().SelectMany(outer => outer.Inners.Select(inner => inner.Id)).Distinct());
            HashSet<int> firstOuterIds = new HashSet<int>(GetFirstOuterList().Select(outer => outer.Id).Distinct());
            HashSet<int> secondInnerIds = new HashSet<int>(GetSecondOuterList().SelectMany(outer => outer.Inners.Select(inner => inner.Id)).Distinct());
            HashSet<int> secondOuterIds = new HashSet<int>(GetSecondOuterList().Select(outer => outer.Id).Distinct());
            bool isInnerSubset = secondInnerIds.IsSubsetOf(firstInnerIds);
            bool isOuterSubset = secondOuterIds.IsSubsetOf(firstOuterIds);
            Assert.IsTrue(isInnerSubset);
            Assert.IsTrue(isOuterSubset);
        }
        [TestMethod]
        public void ICanSeeWhenInnerAndOuterCollectionsAreNotSubsets()
        {
            HashSet<int> firstInnerIds = new HashSet<int>(GetFirstOuterList().SelectMany(outer => outer.Inners.Select(inner => inner.Id)).Distinct());
            HashSet<int> firstOuterIds = new HashSet<int>(GetFirstOuterList().Select(outer => outer.Id).Distinct());
            HashSet<int> secondInnerIds = new HashSet<int>(GetSecondOuterList().SelectMany(outer => outer.Inners.Select(inner => inner.Id)).Distinct());
            HashSet<int> secondOuterIds = new HashSet<int>(GetSecondOuterList().Select(outer => outer.Id).Distinct());
            firstInnerIds.Clear();
            firstInnerIds.Add(5);
            firstOuterIds.Clear();
            firstOuterIds.Add(5);
            bool isInnerSubset = secondInnerIds.IsSubsetOf(firstInnerIds);
            bool isOuterSubset = secondOuterIds.IsSubsetOf(firstOuterIds);
            Assert.IsFalse(isInnerSubset);
            Assert.IsFalse(isOuterSubset);
        }
       private List<FirstOuter> GetFirstOuterList()  { ... }
       private List<SecondOuter> GetSecondOuterList()  { ... }
