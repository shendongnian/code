    public class TestClass
        {
            private int _col1;
            private char _col2;
            private int _col3;
            private int _col4;
            private int _col5;
    
            public TestClass(int c1, char c2, int c3, int c4, int c5)
            {
                _col1 = c1;
                _col2 = c2;
                _col3 = c3;
                _col4 = c4;
                _col5 = c5;
            }
    
            public int Col1
            {
                get { return _col1; }
                set { _col1 = value; }
            }
    
            public char Col2
            {
                get { return _col2; }
                set { _col2 = value; }
            }
    
            public int Col3
            {
                get { return _col3; }
                set { _col3 = value; }
            }
    
            public int Col4
            {
                get { return _col4; }
                set { _col4 = value; }
            }
    
            public int Col5
            {
                get { return _col5; }
                set { _col5 = value; }
            }
        }
