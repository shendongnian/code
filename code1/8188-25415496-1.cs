        class Counter
        {
            public int count { get; private set; }
            void incr(int value) { count += value; }
        }
        [Test]
        public void making_questionable_life_choices()
        {
            Counter c = new Counter ();
            c.call ("incr", 2);             // "incr" is private !
            c.call ("incr", 3);
            Assert.AreEqual (5, c.count);
        }
