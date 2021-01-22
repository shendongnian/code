        [TestMethod]
        public void Scanl_Test()
        {
            var xs = new int[] { 1, 2, 3, 4, 5, 6, 7 };
            var lazyYs = xs.Scanl(0, (y, x) => y + x);
            var ys = lazyYs.ToArray();
            Assert.AreEqual(ys[0], 0);
            Assert.AreEqual(ys[1], 1);
            Assert.AreEqual(ys[2], 3);
            Assert.AreEqual(ys[3], 6);
            Assert.AreEqual(ys[4], 10);
            Assert.AreEqual(ys[5], 15);
            Assert.AreEqual(ys[6], 21);
            Assert.AreEqual(ys[7], 28);
        }
