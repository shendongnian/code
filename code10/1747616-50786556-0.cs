        MyTableClient1 foo = new MyTableClient1(myTable);
        MyTableClient2 bar = new MyTableClient2(myTable);
        MyTableClient3 baz = new MyTableClient3(myTable);
        
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
