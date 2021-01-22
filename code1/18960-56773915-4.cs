    class MyList
    {
        private string[]                 MBuffer;
        public MyList()
        {
            MBuffer=new string[100];
        }
        public string this[int Index]
        {
            get
            {
                return(MBuffer[Index]);
            }
            set
            {
                MBuffer[Index]=value;
            }
        }
    }
    MyList   List=new MyList();
    List[10]="ABC";
    Console.WriteLine(List[10]);
