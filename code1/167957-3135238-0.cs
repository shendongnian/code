    public interface IFacility
    {
        IEnumerable<BrokenRules> GetBrokenRules();
    }
    public static class Utils
    {
        public static IEnumerable<BrokenRules> GetRules(this IEnumerable<IFacility> facilities)
        {
            return facilities.SelectMany(x => x.GetBrokenRules());
        }
    }
