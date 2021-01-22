    public static class StringExtensions
    {
        public static String AddFullStop(this String data)
        {
            return data + ".";
        }
    }
    String input = "test";
    String output = input.AddFullStop();
