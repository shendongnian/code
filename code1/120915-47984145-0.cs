    using System.Threading;
    public class AtomicFlag
    {
        public const int SETVALUE = 1;
        public const int RESETVALUE = 0;
        /// <summary>
        /// Represents the current state of the flag.
        /// 0 means false (or reset).
        /// 1 means true (or set).
        /// </summary>
        private int Value;
        /// <summary>
        /// Creates an atomicflag with the specified default value.
        /// </summary>
        /// <param name="initialValue">AtomicFlag.SETVALUE or 
        /// AtomicFlag.RESETVALUE. Defaults to RESETVALUE.</param>
        public AtomicFlag(int initialValue = RESETVALUE)
        {
            Guard.AgainstUnsupportedValues<int>(initialValue, "initialValue",
               new int[] { SETVALUE, RESETVALUE });
            Value = initialValue;
        }
        public void Set()
        {
            Value = SETVALUE;
        }
        public void Reset()
        {
            Value = RESETVALUE;
        }
        public bool TestAndSet()
        {
            // Use Interlocked to test if the current value is RESETVALUE,
            // return true and set value to SETVALUE.
            //
            // From Interlocked.CompareExchange help:
            // public static int CompareExchange(
            //    ref int location1,
            //    int value,
            //    int comparand
            // )
            // where
            //  location1: The destination, whose value is compared with 
            //             comparand and possibly replaced.
            //  value:     The value that replaces the destination value if the
            //             comparison results in equality.
            //  comparand: The value that is compared to the value at
            //             location1. 
            return (RESETVALUE == Interlocked.CompareExchange(
                ref Value, SETVALUE, RESETVALUE));
        }
        public bool TestAndReset()
        {
            // If the current value is SETVALUE, return true and change value 
            // to RESETVALUE.
            return (SETVALUE ==
                Interlocked.CompareExchange(ref Value, RESETVALUE, SETVALUE));
        }
    }
