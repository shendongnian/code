        MyTableClient1 foo;
        MyTableClient2 bar;
        MyTableClient3 baz;
        
        private MyTable _myTable;
        public MyTable myTable
        {
            get { return _myTable; }
            set 
                { 
                    foo = new MyTableClient1(value);
                    bar = new MyTableClient2(value);
                    baz = new MyTableClient3(value);
                
                    _myTable = value;  
                }
        }
