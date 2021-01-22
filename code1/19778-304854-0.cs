        [Test]
        public void CanGetSelectedItems()
        {
            // simple test to make sure that the SelectedIndices
            // property is updated
            using (var f = new DummyForm(listView))
            {
                f.Show();
                listView.SelectedIndices.Add(0);
                Assert.AreEqual(1, listView.SelectedIndices.Count);
            }
        }
        private class DummyForm : Form
        {
            public DummyForm(ListView listView)
            {
                // Minimize and make it not appear in taskbar to
                // avoid flicker etc when running the tests
                this.WindowState = FormWindowState.Minimized;
                this.ShowInTaskbar = false;
                this.Controls.Add(listView);
            }
        }
