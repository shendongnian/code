    [Flags]
    enum MonthsOfYear
    {        
        January = 1,
        February = 2,
        March = 4,
        April = 8,
        May = 16,
        June = 32,
        July = 64,
        August = 128,
        September = 256,
        October = 512,
        November = 1024,
        December = 2048
    }
	public class Months
    {
        internal static MonthsOfYear CalculateEnum(List<bool> checkboxes)
        {
            MonthsOfYear value = 0;
            var month = 0;
            for (int i = 0; i < 12; i++)
            {
                month = (i == 0) ? 1 : month * 2;
                if (checkboxes[i])
                    value |= (MonthsOfYear)Enum.Parse(typeof(MonthsOfYear), month.ToString());
            }
            return value;
        }
        internal static List<bool> GetFlagsFromEnum(MonthsOfYear value)
        {
            List<bool> checkboxes = new List<bool>();
            var month = 0;
            for (int i = 0; i < 12; i++)
            {
                month = (i == 0) ? 1 : month * 2;
                checkboxes.Add((value & (MonthsOfYear)Enum.Parse(typeof(MonthsOfYear), month.ToString())) != 0);
            }
            return checkboxes;
        }
    }
