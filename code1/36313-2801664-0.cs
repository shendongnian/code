    enum MyEnum
    {
        AA = 'A',
        BB = 'B',
        CC = 'C'
    };
    
    static void Main(string[] args)
    {
        MyEnum e = MyEnum.AA;
        char value = (char)e.GetHashCode(); //value = 'A'
    }
