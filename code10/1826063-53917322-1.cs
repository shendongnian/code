    public interface ILetter
    {
        bool Italic{ get; }
    }
    public interface IUpperCaseLetter : ILetter
    {
        ILowerCaseLetter ToLowerCase();
    }
    
    public interface ILowerCaseLetter : ILetter
    {
        IUpperCaseLetter ToUpperCase();
    }
