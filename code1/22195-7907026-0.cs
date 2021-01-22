        public static bool CanBeTreatedAsType(this Type CurrentType, Type TypeToCompareWith)
        {
            // Always return false if either Type is null
            if (CurrentType == null || TypeToCompareWith == null)
                return false;
            // Return the result of the assignability test
            return TypeToCompareWith.IsAssignableFrom(CurrentType);
        }
