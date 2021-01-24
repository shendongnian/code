    namespace MyProj {
        public partial class BuildDetails {
            static string buildDate = "build_date";
            public static string dispBuildDate() {
                getBuildDate();
                return buildDate;
            }
        static partial void getBuildDate();
    }
