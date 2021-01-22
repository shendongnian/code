    public class Conditional
    {
        private int _numberOfManuals;
        private string _serviceType;
        public const int SMALL = 2;
        public const int MEDIUM = 8;
        public int NumberOfManuals { get { return _numberOfManuals; } }
        public string ServiceType { get { return _serviceType; } }
        private Dictionary<int, IResult> resultStrategy;
        public Conditional(int numberOfManuals, string serviceType)
        {
            _numberOfManuals = numberOfManuals;
            _serviceType = serviceType;
            resultStrategy = new Dictionary<int, IResult>
            {
                  { SMALL, new SmallResult() },
                  { MEDIUM, new MediumResult() },
                  { MEDIUM + 1, new LargeResult() }
            };
        }
        public int GetHours()
        {
            return resultStrategy.Where(k => _numberOfManuals <= k.Key).First().Value.GetResult(this);
        }
    }
    public interface IResult
    {
        int GetResult(Conditional conditional);
    }
    public class SmallResult : IResult
    {
        public int GetResult(Conditional conditional)
        {
            return conditional.ServiceType.IsWriting() ? WritingResult(conditional) : AnalysisResult(conditional); ;
        }
        private int WritingResult(Conditional conditional)
        {
            return 30 * conditional.NumberOfManuals;
        }
        private int AnalysisResult(Conditional conditional)
        {
            return 10;
        }
    }
    public class MediumResult : IResult
    {
        public int GetResult(Conditional conditional)
        {
            return conditional.ServiceType.IsWriting() ? WritingResult(conditional) : AnalysisResult(conditional); ;
        }
        private int WritingResult(Conditional conditional)
        {
            return (Conditional.SMALL * 30) + (20 * conditional.NumberOfManuals - Conditional.SMALL);
        }
        private int AnalysisResult(Conditional conditional)
        {
            return 20;
        }
    }
    public class LargeResult : IResult
    {
        public int GetResult(Conditional conditional)
        {
            return conditional.ServiceType.IsWriting() ? WritingResult(conditional) : AnalysisResult(conditional); ;
        }
        private int WritingResult(Conditional conditional)
        {
            return (Conditional.SMALL * 30) + (20 * (Conditional.MEDIUM - Conditional.SMALL)) + (10 * conditional.NumberOfManuals - Conditional.MEDIUM);
        }
        private int AnalysisResult(Conditional conditional)
        {
            return 30;
        }
    }
    public static class ExtensionMethods
    {
        public static bool IsWriting(this string value)
        {
            return value == "writing";
        }
    }
