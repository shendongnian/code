    public static class Serializers {
        public static ISerializer Create() {
            var version = typeof(JsonConvert).Assembly.GetName().Version;
            if (version.Major == 10)
                return new Js10Serializer();
            return new Js11Serializer();
        }
    }
