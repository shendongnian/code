      public static void ToCombo<T>(this T type)
        {
            if (typeof(T).BaseType != typeof(Enum))
            {
                throw new InvalidCastException();
            }
            var arrValues = Enum.GetValues(typeof(T));
        }
