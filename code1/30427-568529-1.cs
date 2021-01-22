        [TestMethod()]
        public void ConstructorCreatesEmptyList() {
            Target t = new Target();
            Assert.AreEqual<int>(0, t.ComboDataView.Count);
            Assert.AreEqual<int>(-1, t.Combo.SelectedMinutes);
            Assert.IsNull(t.Combo.SelectedItem);
        }
