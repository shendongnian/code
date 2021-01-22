    using System;
    using Microsoft.VisualStudio.TestTools.UnitTesting;
    namespace YourProject.Tests
    {
        public static class MyAssert
        {
            /// <summary>
            /// Helper for Asserting that a function throws an exception of a particular type.
            /// </summary>
            public static void Throws<T>( Action func ) where T : Exception
            {
                Exception exceptionOther = null;
                var exceptionThrown = false;
                try
                {
                    func.Invoke();
                }
                catch ( T )
                {
                    exceptionThrown = true;
                }
                catch (Exception e) {
                    exceptionOther = e;
                }
                if ( !exceptionThrown )
                {
                    if (exceptionOther != null) {
                        throw new AssertFailedException(
                            String.Format("An exception of type {0} was expected, but not thrown. Instead, an exception of type {1} was thrown.", typeof(T), exceptionOther.GetType()),
                            exceptionOther
                            );
                    }
                    throw new AssertFailedException(
                        String.Format("An exception of type {0} was expected, but no exception was thrown.", typeof(T))
                        );
                }
            }
        }
    }
