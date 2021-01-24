    public abstract class Country<TStates> 
        where TStates: struct, IConvertible, IFormattable, IComparable
    {
        public abstract TStates[] States { get; }
    }
    public enum UnitedStatesStates
    {
        WhoCares, WhoCares2
    }
    public class UnitedStatesCountry : Country<UnitedStatesStates>
    {
        public override UnitedStatesStates[] States { get; }
    }
