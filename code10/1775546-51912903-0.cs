    interface IPerson
    {
        string GetIdentity();
    }
    public class AmericanCitizen : IPerson
    {
        public string GetIdentity() => SSN.ToString();
    }
    public class StackOverflowPoster : IPerson
    {
        public string GetIdentity() => Alias;
    }
