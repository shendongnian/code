    namespace Extension {
        public static class ExtensionMethods {
            public static string EnumValue(this MyEnum e) {
                switch (e) {
                    case MyEnum.First:
                        return "First Friendly Value";
                    case MyEnum.Second:
                        return "Second Friendly Value";
                    case MyEnum.Third:
                        return "Third Friendly Value";
                }
                return "Horrible Failure!!";
            }
        }
    }
