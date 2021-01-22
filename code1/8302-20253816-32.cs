    namespace Common.FluentValidation
    {
        public static partial class Validate
        {
            /// <summary>
            /// Validates the passed in parameter matches at least one of the passed in comparisons.
            /// </summary>
            /// <typeparam name="T"></typeparam>
            /// <param name="p_parameter">Parameter to validate.</param>
            /// <param name="p_comparisons">Values to compare against.</param>
            /// <returns>True if a match is found.</returns>
            /// <exception cref="ArgumentNullException"></exception>
            public static bool IsAnyOf<T>(this T p_parameter, params T[] p_comparisons)
            {
                // Validate
                p_parameter
                    .CannotBeNull("p_parameter");
                p_comparisons
                    .CannotBeNullOrEmpty("p_comparisons");
                // Test for any match
                foreach (var item in p_comparisons)
                    if (p_parameter.Equals(item))
                        return true;
                // Return no matches found
                return false;
            }
        }
    }
