    public interface IHaveIdentity {
        string Identity { get; }
    }
    public class AmericanCitizen : IPerson, IHaveIdentity {
        //etc
