    public static class GenericExtension
    {
        public static Nullable<Double> ConvertToNullableDouble(this String s)
        {
            Double value;
            if (Double.TryParse(s, out value))
            {
                return value;
            }
            else
            {
                return null;
            }
        }
    }
