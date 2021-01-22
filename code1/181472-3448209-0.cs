    public static class Converters
    {
        public static Converter CreateConverter1()
        {
            return new Converter(new Reader1());
        }
        public static Converter CreateConverter2()
        {
            return new Converter(new Reader2());
        }
    }
