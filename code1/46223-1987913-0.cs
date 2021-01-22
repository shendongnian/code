        [Test]
        public void ColorTransform()
        {
            var argbInt = Color.LightCyan.ToArgb();
            Color backColor = Color.FromArgb(argbInt);
            Assert.AreEqual(Color.LightCyan.A, backColor.A);
            Assert.AreEqual(Color.LightCyan.B, backColor.B);
            Assert.AreEqual(Color.LightCyan.G, backColor.G);
            Assert.AreEqual(Color.LightCyan.R, backColor.R);
        }
