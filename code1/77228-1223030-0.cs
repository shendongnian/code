    class Program
    {
        static void Main(string[] args)
        {
            object sampleObject = GetSampleObject();
            FieldInfo[] testStructFields = typeof(Test).GetFields();
            foreach (FieldInfo testStructField in testStructFields)
            {
                if (testStructField.FieldType.IsArray)
                {
                    // We can cast to ILIst because arrays implement it and we verfied that it is an array in the if statement
                    System.Collections.IList sampleObject_test1 = (System.Collections.IList)testStructField.GetValue(sampleObject);
                    // We can now get the first element of the array of Test2s:
                    object sampleObject_test1_Element0 = sampleObject_test1[0];
                    // I hope this the FieldInfo that you want to get:
                    FieldInfo myValueFieldInfo = sampleObject_test1_Element0.GetType().GetField("MyValue");
                    // Now it is possible to read and write values
                    object sampleObject_test1_Element0_MyValue = myValueFieldInfo.GetValue(sampleObject_test1_Element0);
                    Console.WriteLine(sampleObject_test1_Element0_MyValue); // prints 99
                    myValueFieldInfo.SetValue(sampleObject_test1_Element0, 55);
                    sampleObject_test1_Element0_MyValue = myValueFieldInfo.GetValue(sampleObject_test1_Element0);
                    Console.WriteLine(sampleObject_test1_Element0_MyValue); // prints 55
                }
            }
        }
        static object GetSampleObject()
        {
            Test sampleTest = new Test();
            sampleTest.Test1 = new Test2[5];
            sampleTest.Test1[0] = new Test2() { MyValue = 99 };
            object sampleObject = sampleTest;
            return sampleObject;
        }
    }
    [StructLayout(LayoutKind.Sequential)]
    public struct Test2
    {
        public int MyValue;
    }
    [StructLayout(LayoutKind.Sequential)]
    public struct Test
    {
        public byte Byte1;
        [MarshalAs(UnmanagedType.ByValArray, SizeConst = 3)]
        public Test2[] Test1;
    }
