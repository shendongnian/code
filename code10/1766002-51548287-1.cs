    interface IMinMaxStringGenerator
    {
        string GenerateMinMaxString(int minLength,int maxLength);
    }
    class MinMaxStringGenerator:IMinMaxStringGenerator
    {
        ....
         IFixStringGenerator _fixStringGenerator;
         public MinMaxStringGenerator(IFixStringGenerator fixStringGenerator)
         {
            _fixStringGenerator=fixStringGenerator;
         }
        string GenerateMinMaxString(int minLength,int maxLength)
        {
         /// do the things with fix generator "_fixStringGenerator"
        }
        ....
     }
