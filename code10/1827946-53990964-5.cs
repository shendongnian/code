    public static partial class RateExtensions
    {
        public static bool TryGetConversion(this Dictionary<string, Rate> rates, string from, string to, out decimal rate)
        {
            Rate fromRate;
            Rate toRate;
            if (rates == null || !rates.TryGetValue(from, out fromRate))
            {
                rate = 0;
                return false;
            }
            if (!rates.TryGetValue(to, out toRate))
            {
                rate = 0;
                return false;
            }
            rate = toRate.rate / fromRate.rate;
            return true;
        }
    }
