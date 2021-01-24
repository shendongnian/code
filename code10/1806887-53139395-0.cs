    [Flags]
    public enum MyEnum
    {
        FlagA = 16,          //0b010000
        FlagB = 32,          //0b100000
    }
    
    .
    .
    
    MyEnum e = MyEnum.FlagA; //0b010000
    e += 6;                  //0b010000 + 0b000110 EQUALS 0b010110
    int x = (int)e & 15      //15=0b001111 AND e=0b010110 EQUALS 0b000110
    Console.Write(x);        //6
    Console.WriteLine(e.HasFlag(MyEnum.A)); //true
