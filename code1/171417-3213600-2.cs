    class Program
    {
        enum ReportStatus
        {
            Assigned = 1,
            Analyzed = 2,
            Written = 3,
            Reviewed = 4,
            Finished = 5,
        }
        static void Main(string[] args)
        {
            Array values = Enum.GetValues(typeof(ReportStatus));
            Console.WriteLine("Type of array: {0}", values.GetType().FullName);
            // Case 1: iterating over values as System.Array, loop variable is of type System.Object
            // The foreach loop uses an IEnumerator obtained from System.Array.
            // The IEnumerator's Current property uses the System.Array.GetValue method to retrieve the current value.
            // At that time, the current ReportStatus value is boxed as System.Object.
            // The value variable is passed to Console.WriteLine(System.Object).
            // Summary: 1 box operation, 0 unbox operations
            Console.WriteLine("foreach (object value in values)");
            foreach (object value in values)
            {
                Console.WriteLine(value);
            }
            // Case 2: iterating over values as System.Array, loop variable is of type ReportStatus
            // The foreach loop uses an IEnumerator obtained from System.Array.
            // The IEnumerator's Current property uses the System.Array.GetValue method to retrieve the current value.
            // At that time, the current ReportStatus value is boxed as System.Object.
            // The current value is immediatly unboxed as ReportStatus to be assigned to the loop variable, value.
            // The value variable is then boxed again so that it can be passed to Console.WriteLine(System.Object).
            // Summary: 2 box operations, 1 unbox operation
            Console.WriteLine("foreach (ReportStatus value in values)");
            foreach (ReportStatus value in values)
            {
                Console.WriteLine(value);
            }
            // Case 3: iterating over values as System.Array, loop variable is of type System.Int32.
            // The foreach loop uses an IEnumerator obtained from System.Array.
            // The IEnumerator's Current property uses the System.Array.GetValue method to retrieve the current value.
            // At that time, the current ReportStatus value is boxed as System.Object.
            // The current value is immediatly unboxed as System.Int32 to be assigned to the loop variable, value.
            // The value variable is passed to Console.WriteLine(System.Int32).
            // Summary: 1 box operation, 1 unbox operation
            Console.WriteLine("foreach (int value in values)");
            foreach (int value in values)
            {
                Console.WriteLine(value);
            }
            // Case 4: iterating over values as ReportStatus[], loop variable is of type System.Object.
            // The foreach loop is compiled as a simple for loop; it does not use an enumerator.
            // On each iteration, the current element of the array is assigned to the loop variable, value.
            // At that time, the current ReportStatus value is boxed as System.Object.
            // The value variable is passed to Console.WriteLine(System.Object).
            // Summary: 1 box operation, 0 unbox operations
            Console.WriteLine("foreach (object value in (ReportStatus[])values)");
            foreach (object value in (ReportStatus[])values)
            {
                Console.WriteLine(value);
            }
            // Case 5: iterating over values as ReportStatus[], loop variable is of type ReportStatus.
            // The foreach loop is compiled as a simple for loop; it does not use an enumerator.
            // On each iteration, the current element of the array is assigned to the loop variable, value.
            // The value variable is then boxed so that it can be passed to Console.WriteLine(System.Object).
            // Summary: 1 box operation, 0 unbox operations
            Console.WriteLine("foreach (ReportStatus value in (ReportStatus[])values)");
            foreach (ReportStatus value in (ReportStatus[])values)
            {
                Console.WriteLine(value);
            }
            // Case 6: iterating over values as ReportStatus[], loop variable is of type System.Int32.
            // The foreach loop is compiled as a simple for loop; it does not use an enumerator.
            // On each iteration, the current element of the array is assigned to the loop variable, value.
            // The value variable is passed to Console.WriteLine(System.Int32).
            // Summary: 0 box operations, 0 unbox operations
            Console.WriteLine("foreach (int value in (ReportStatus[])values)");
            foreach (int value in (ReportStatus[])values)
            {
                Console.WriteLine(value);
            }
            // Case 7: The compiler evaluates var to System.Object.  This is equivalent to case #1.
            Console.WriteLine("foreach (var value in values)");
            foreach (var value in values)
            {
                Console.WriteLine(value);
            }
            // Case 8: The compiler evaluates var to ReportStatus.  This is equivalent to case #5.
            Console.WriteLine("foreach (var value in (ReportStatus[])values)");
            foreach (var value in (ReportStatus[])values)
            {
                Console.WriteLine(value);
            }
        }
    }
