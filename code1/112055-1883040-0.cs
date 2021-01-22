        private class Test
        {
            public int MyInt = 1;
            public double MyDouble = 2d;
        }
        Test test = new Test();
        public int PubTest
        {
            get { return test.MyInt; }
        }
