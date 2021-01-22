    public class Const_V_Readonly
    {
      public const int I_CONST_VALUE = 2;
      public readonly char[] I_RO_VALUE = new Char[]{'a', 'b', 'c'};
      public UpdateReadonly()
      {
         I_RO_VALUE[0] = 'V'; //perfectly legal and will update the value
         I_RO_VALUE = new char[]{'V'}; //will cause compiler error
      }
    }
