    public partial class Savestate
    {
        public static List<string> rtb1_list = new List<string>() { "hi", "bye" };
        public static List<string> rtb2_list = new List<string>() { "hi", "bye" };
        public static List<string> rtb3_list = new List<string>() { "hi", "bye" };
        public static List<string> rtb4_list = new List<string>() { "hi", "bye" };
    }
    public static class SavestateExtensions
    {
        public static string GetRtbListAsString(this IEnumerable<string> rtb_list)
        {
            StringBuilder str = new StringBuilder();
            foreach (var value in rtb_list)
            {
                str.AppendLine(value);
            }
            return str.ToString();
        }
    }
