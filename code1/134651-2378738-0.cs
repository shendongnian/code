    private class ThreadArguments
    {    
        public ArrayList List1 { get; set; }
        public ArrayList List2 { get; set; }
    
        public ThreadArguments(ArrayList list1, ref ArrayList list2)
        {
            this.List1 = list1;
            this.List2 = list2;
        }
    }
    Thread myThread = new Thread(new ParameterizedThreadStart(...));
    myThread.Start(args);
