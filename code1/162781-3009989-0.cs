    class Program
    {
        static void Main(string[] args) {
            string msg = "AAABBBCC";
            string[] test = msg.SplitByLength(3);            
        }
    }
    public static class SplitStringByLength
    {
        public static string[] SplitByLength(this string inputString, int segmentSize) {
            List<string> segments = new List<string>();
            int wholeSegmentCount = inputString.Length / segmentSize;
            int i;
            for (i = 0; i < wholeSegmentCount; i++) {
                segments.Add(inputString.Substring(i * segmentSize, segmentSize));
            }
            if (inputString.Length % segmentSize != 0) {
                segments.Add(inputString.Substring(i * segmentSize, inputString.Length - i * segmentSize));
            }
            return segments.ToArray();
        }
    }
