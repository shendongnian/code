    public static class TimeZoneInfoExtensions {
            public static string Abbreviation(this TimeZoneInfo Source) {
            var Map = new Dictionary<string, string>()
            {
                {"eastern standard time","est"},
                {"mountain standard time","mst"},
                {"central standard time","cst"},
                {"pacific standard time","pst"}
                //etc...
            };
            return Map[Source.Id.ToLower()].ToUpper();
        }
    }
