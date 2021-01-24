    public static void Main()
    {
        StreamWriter sw = new StreamWriter("data.txt");
        StreamReader sr = new StreamReader("data.txt"); //: 'The process cannot access the 
                                                        // file 'data.txt' because it is being used 
                                                        // by another process.'
    }
