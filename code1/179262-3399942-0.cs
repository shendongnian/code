    public class XYZ
    {
        // Don't do this! Horribly unsafe!
        private static int b;
        public static int A(int value)
        {
            b = value;
            return b;
        }
    }
