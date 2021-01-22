    using System;
    namespace Common.FluentValidation
    {
        public static partial class Validators
        {
            /// <summary>
            /// Validates the passed in parameter is not null, throwing a detailed exception message if the test fails.
            /// </summary>
            /// <param name="p_parameter">Parameter to validate.</param>
            /// <param name="p_name">Name of tested parameter to assist with debugging.</param>
            /// <exception cref="ArgumentNullException"></exception>
            public static void CannotBeNull(this object p_parameter, string p_name)
            {
                if (p_parameter == null)
                    throw
                        new
                            ArgumentNullException(
                            string.Format("Parameter \"{0}\" cannot be null.",
                            p_name), default(Exception));
            }
        }
    }
