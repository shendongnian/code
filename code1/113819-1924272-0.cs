    public enum EnumTest
    {
        EnumOne,
        EnumTwo,
        EnumThree,
        Unknown
    };
    public class EnumTestingClass{
        [STAThread]
        static void Main()
        {
            EnumTest tstEnum = EnumTest.Unknown;
            object objTestEnum;
            objTestEnum = Enum.Parse(tstEnum.GetType(), "EnumThree");
            if (objTestEnum is EnumTest)
            {
                EnumTest newTestEnum = (EnumTest)objTestEnum;
                Console.WriteLine("newTestEnum = {0}", newTestEnum.ToString());
            }
        }
    }
