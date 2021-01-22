        public static void Main()
        {
            int test = MyCSharpWrapperMethod(TestEnum.Test1);
            Debug.Assert(test == 1);
        }
        public static int MyCSharpWrapperMethod(TestEnum customFlag)
        {
            return MyCPlusPlusMethod(customFlag.GetValue<int>());
        }
        public static int MyCPlusPlusMethod(int customFlag)
        {
            //Pretend you made a PInvoke or COM+ call to C++ method that require an integer
            return customFlag;
        }
        public enum TestEnum
        {
            Test1 = 1,
            Test2 = 2,
            Test3 = 3
        }
    }
    public static class EnumExtensions
    {
        public static T GetValue<T>(this Enum enumeration)
        {
            T result = default(T);
            try
            {
                result = (T)Convert.ChangeType(enumeration, typeof(T));
            }
            catch (Exception ex)
            {
                Debug.Assert(false);
                Debug.WriteLine(ex);
            }
            return result;
        }
    }    
