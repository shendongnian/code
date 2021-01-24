    using System;
    using System.Windows.Forms;
    
    namespace WindowsFormsApp1
    {
        public class Example1 : CheckedListBox
        {
            public override int ItemHeight
            {
                get { return 100; }
            }
        }
    
        public class Example2 : CheckedListBox
        {
            private readonly Func<int> _itemHeight;
    
            public Example2(Func<int> itemHeight)
            {
                _itemHeight = itemHeight;
            }
    
            public override int ItemHeight
            {
                get { return _itemHeight(); }
            }
        }
    
        public class Example2Test
        {
            public Example2Test()
            {
                var example2 = new Example2(GetItemHeight);
            }
    
            private int GetItemHeight()
            {
                return 100;
            }
        }
    }
