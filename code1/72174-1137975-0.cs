    using System.Linq;
    
            /// <summary>
            /// Test to see if value is in specified range.
            /// </summary>
            /// <param name="aStart">int</param>
            /// <param name="aEnd">int</param>
            /// <param name="aValueToTest">int</param>
            /// <returns>bool</returns>
            public static bool CheckValueInRange(int aStart, int aEnd, int aValueToTest)
            {
                // check value in range...
                bool ValueInRange = Enumerable.Range(aStart, aEnd).Contains(aValueToTest);
                // return value...
                return ValueInRange;
            }
