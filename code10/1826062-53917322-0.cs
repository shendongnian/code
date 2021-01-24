    public interface IUpperCaseLetter
    {
        ILowerCaseLetter ToLowerCase();
    }
    
    public interface ILowerCaseLetter
    {
        IUpperCaseLetter ToUpperCase();
    }
    
    public class UpperA : IUpperCaseLetter
    {
        public ILowerCaseLetter ToLowerCase()
        {
            return new LowerA();
        }
    }
    
    public class LowerA : ILowerCaseLetter
    {
        public IUpperCaseLetter ToUpperCase()
        {
            return new UpperA();
        }
    }
    foreach (var upperLetter in setOfImaginaryBuiltLetterObjects)
    {
         var lowerLetter = upperLetter.ToLowerCase();
    }
