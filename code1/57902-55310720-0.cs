    public static class TestableExtensions
    {
        public static string GetDesc(this ITestable ele)
        {
            return "Extension GetDesc";
        }
        public static void ValDesc(this ITestable ele, string choice)
        {
            if (choice == "ext def")
            {
                Console.WriteLine($"Base.Ext.Ext.GetDesc: {ele.GetDesc()}");
            }
            else if (choice == "ext base" && ele is BaseTest b)
            {
                Console.WriteLine($"Base.Ext.Base.GetDesc: {b.BaseFunc()}");
            }
        }
        public static string ExtFunc(this ITestable ele)
        {
            return ele.GetDesc();
        }
        public static void ExtAction(this ITestable ele, string choice)
        {
            ele.ValDesc(choice);
        }
    }
    public interface ITestable
    {
    }
    public class BaseTest : ITestable
    {
        public string GetDesc()
        {
            return "Base GetDesc";
        }
        public void ValDesc(string choice)
        {
            if (choice == "")
            {
                Console.WriteLine($"Base.GetDesc: {GetDesc()}");
            }
            else if (choice == "ext")
            {
                Console.WriteLine($"Base.Ext.GetDesc: {this.ExtFunc()}");
            }
            else
            {
                this.ExtAction(choice);
            }
        }
        public string BaseFunc()
        {
            return GetDesc();
        }
    }
