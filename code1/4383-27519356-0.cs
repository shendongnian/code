    public enum MyEnum { A = 1, B = 2, C = 4 }
    public const MyEnum D = (MyEnum)(8);
    public const MyEnum E = (MyEnum)(16);
    func1{
        MyEnum EnumValue = D;
        switch (EnumValue){
          case D:  break;
          case E:  break;
          case MyEnum.A:  break;
          case MyEnum.B:  break;
       }
    }
