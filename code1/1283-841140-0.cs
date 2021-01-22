        public static bool Contains(
              this MyEnumType enumValue,
              MyEnumType flagValue)
        {
            return ((enumValue & flagValue) == flagValue);
        }
        public static bool ContainsAny(
              this MyEnumType enumValue,
              MyEnumType flagValue)
        {
            return ((enumValue & flagValue) > 0);
        }
