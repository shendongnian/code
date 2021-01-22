    using System;
    using System.Collections.Generic;
    using Common.FluentValidation;
    using NUnit.Framework;
    namespace UnitTests.Common.Fluent_Validations
    {
        [TestFixture]
        public class IsAnyOf_Tests
        {
            [Test, ExpectedException(typeof(ArgumentNullException))]
            public void IsAnyOf_ArgumentNullException_ShouldNotMatch_ArgumentException_Test()
            {
                Action TestMethod = () => { throw new ArgumentNullException(); };
                try
                {
                    TestMethod();
                }
                catch (Exception ex)
                {
                    if (ex.GetType().IsAnyOf(
                        typeof(ArgumentException), /*Note: ArgumentNullException derrived from ArgumentException*/
                        typeof(FormatException),
                        typeof(KeyNotFoundException)))
                    {
                        // Handle expected Exceptions
                        return;
                    }
                    //else throw original
                    throw;
                }
            }
            [Test, ExpectedException(typeof(OutOfMemoryException))]
            public void IsAnyOf_OutOfMemoryException_ShouldMatch_OutOfMemoryException_Test()
            {
                Action TestMethod = () => { throw new OutOfMemoryException(); };
                try
                {
                    TestMethod();
                }
                catch (Exception ex)
                {
                    if (ex.GetType().IsAnyOf(
                        typeof(OutOfMemoryException),
                        typeof(StackOverflowException)))
                        throw;
                    /*else... Handle other exception types, typically by logging to file*/
                }
            }
        }
    }
