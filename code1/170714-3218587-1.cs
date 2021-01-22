    namespace AppleExtensionMethods
    {
        using System;
        using ConsoleApplication1;
    
       // Accessors for Seed Properties
        public static class Seed
        {
            public static float GetSeedCount(this Apple apple)
            {
                return Convert.ToSingle(apple["SeedCount"]);
            }
    
            public static void SetSeedCount(this Apple apple, string count)
            {
                apple["SeedCount"] = count;
            }
        }
    
       // Accessors for Skin Properties
        public static class Skin
        {
            public static string GetSkinColor(this Apple apple)
            {
                return apple["Color"];
            }
    
            public static void SetSkinColor(this Apple apple, string color)
            {
                apple["Color"] = ValidSkinColorOrDefault(apple, color);
            }
    
            private static string ValidSkinColorOrDefault(this Apple apple, string color)
            {
                switch (color.ToLower())
                {
                    case "red":
                        return color;
    
                    case "green":
                        return color;
    
                    default:
                        return "rotten brown";
                }
            }
        }
    }
