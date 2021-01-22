        class Stuff
        {
            ~Stuff()
            {
            }
        }
        WeakReference CreateWithWeakReference<T>(Func<T> factory)
        {
            return new WeakReference(factory());
        }
        [Test]
        public void TestEverythingOutOfScopeIsReleased()
        {
            var tracked = new List<WeakReference>();
            var referer = new List<Stuff>();
            tracked.Add(CreateWithWeakReference(() => { var stuff = new Stuff(); referer.Add(stuff); return stuff; }));
            // Run some code that is expected to release the references
            referer.Clear();
            GC.Collect();
            Assert.IsFalse(tracked.Any(o => o.IsAlive), "All objects should have been released");
        }
        [Test]
        public void TestLocalVariableIsStillInScope()
        {
            var tracked = new List<WeakReference>();
            var referer = new List<Stuff>();
            for (var i = 0; i < 10; i++)
            {
                var stuff = new Stuff();
                tracked.Add(CreateWithWeakReference(() => { referer.Add(stuff); return stuff; }));
            }
            // Run some code that is expected to release the references
            referer.Clear();
            GC.Collect();
            // Following holds because of the stuff variable is still on stack!
            Assert.IsTrue(tracked.Count(o => o.IsAlive) == 1, "Should still have a reference to the last one from the for loop");
        }
