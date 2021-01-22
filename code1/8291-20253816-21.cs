    using System;
    using System.Collections.Generic;
    using System.Linq;
    using System.Text;
    using Common.FluentValidation;
    namespace IsAnyOfExceptionHandlerSample
    {
        class Program
        {
            static void Main(string[] args)
            {
                // High Level Error Handler (Log and Crash App)
                try
                {
                    Foo();
                }
                catch (OutOfMemoryException ex)
                {
                    Console.WriteLine("FATAL ERROR! System Crashing. " + ex.Message);
                    Console.ReadKey();
                }
            }
            static void Foo()
            {
                // Init
                List<Action<string>> TestActions = new List<Action<string>>()
                {
                    (key) => { throw new FormatException(); },
                    (key) => { throw new ArgumentException(); },
                    (key) => { throw new KeyNotFoundException();},
                    (key) => { throw new OutOfMemoryException(); },
                };
                // Run
                foreach (var FooAction in TestActions)
                {
                    // Mid-Level Error Handler (Log and Break Loop)
                    try
                    {
                        // Init
                        var SomeKeyPassedToFoo = "FooParam";
                        // Low-Level Handler (Handle/Log and Keep going)
                        try
                        {
                            FooAction(SomeKeyPassedToFoo);
                        }
                        catch (Exception ex)
                        {
                            if (ex.GetType().IsAnyOf(
                                typeof(FormatException),
                                typeof(ArgumentException)))
                            {
                                // Handle
                                Console.WriteLine("ex was {0}", ex.GetType().Name);
                                Console.ReadKey();
                            }
                            else
                            {
                                // Add some Debug info
                                ex.Data.Add("SomeKeyPassedToFoo", SomeKeyPassedToFoo.ToString());
                                throw;
                            }
                        }
                    }
                    catch (KeyNotFoundException ex)
                    {
                        // Handle differently (ie. For better access to a variable)
                        Console.WriteLine(ex.Message);
                        int Count = 0;
                        if (!Validate.IsAnyNull(ex, ex.Data, ex.Data.Keys))
                            foreach (var Key in ex.Data.Keys)
                                Console.WriteLine(
                                    "[{0}][\"{1}\" = {2}]",
                                    Count, Key, ex.Data[Key]);
                        Console.ReadKey();
                    }
                }
            }
        }
    }
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
            /// <summary>
            /// Validates if any passed in parameter is equal to null.
            /// </summary>
            /// <param name="p_parameters">Parameters to test for Null.</param>
            /// <returns>True if one or more parameters are null.</returns>
            public static bool IsAnyNull(params object[] p_parameters)
            {
                p_parameters
                    .CannotBeNullOrEmpty("p_parameters");
                foreach (var item in p_parameters)
                    if (item == null)
                        return true;
                return false;
            }
        }
    }
    namespace Common.FluentValidation
    {
        public static partial class Validate
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
    namespace Common.FluentValidation
    {
        public static partial class Validate
        {
            /// <summary>
            /// Validates the passed in parameter is not null or an empty collection, throwing a detailed exception message if the test fails.
            /// </summary>
            /// <typeparam name="T"></typeparam>
            /// <param name="p_parameter">Parameter to validate.</param>
            /// <param name="p_name">Name of tested parameter to assist with debugging.</param>
            /// <exception cref="ArgumentNullException"></exception>
            /// <exception cref="ArgumentOutOfRangeException"></exception>
            public static void CannotBeNullOrEmpty<T>(this ICollection<T> p_parameter, string p_name)
            {
                if (p_parameter == null)
                    throw new ArgumentNullException("Collection cannot be null.\r\nParameter_Name: " + p_name, default(Exception));
                if (p_parameter.Count <= 0)
                    throw new ArgumentOutOfRangeException("Collection cannot be empty.\r\nParameter_Name: " + p_name, default(Exception));
            }
            /// <summary>
            /// Validates the passed in parameter is not null or empty, throwing a detailed exception message if the test fails.
            /// </summary>
            /// <param name="p_parameter">Parameter to validate.</param>
            /// <param name="p_name">Name of tested parameter to assist with debugging.</param>
            /// <exception cref="ArgumentException"></exception>
            public static void CannotBeNullOrEmpty(this string p_parameter, string p_name)
            {
                if (string.IsNullOrEmpty(p_parameter))
                    throw new ArgumentException("String cannot be null or empty.\r\nParameter_Name: " + p_name, default(Exception));
            }
        }
    }
