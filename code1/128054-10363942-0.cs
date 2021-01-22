using System.Collections.Generic;
namespace ConsoleApplication1
{
    class Program
    {
        static void Main(string[] args)
        {
            List<IMyList> myList;
            myList = GetMyList(MyListTypeEnum.MyList1);
            myList = GetMyList(MyListTypeEnum.MyList2);
        }
        public static List<IMyList> GetMyList(MyListTypeEnum tipo)
        {
            List<IMyList> result;
            result = new List<IMyList>();
            switch (tipo)
            {
                case MyListTypeEnum.MyList1:
                    List<MyList1> myList1 = GetMyList1();
                    foreach (var item in myList1)
                    {
                        result.Add((IMyList) item);
                    }
                    break;
                case MyListTypeEnum.MyList2:
                    List<MyList2> myList2 = GetMyList2();
                    foreach (var item in myList2)
                    {
                        result.Add((IMyList) item);
                    }
                    break;
            }
            return result;
        }
        public static List<MyList1> GetMyList1()
        {
            List<MyList1> myList1 = new List<MyList1>();
            myList1.Add(new MyList1 { Code = 1 });
            myList1.Add(new MyList1 { Code = 2 });
            myList1.Add(new MyList1 { Code = 3 });
            return myList1;
        }
        public static List<MyList2> GetMyList2()
        {
            List<MyList2> myList2 = new List<MyList2>();
            myList2.Add(new MyList2 { Name = "1" });
            myList2.Add(new MyList2 { Name = "2" });
            myList2.Add(new MyList2 { Name = "3" });
            return myList2;
        }
    }
    public interface IMyList
    {
    }
    public class MyList1 : IMyList
    {
        public int Code { get; set; }
    }
    public class MyList2 : IMyList
    {
        public string Name { get; set; }
    }
    public enum MyListTypeEnum
    {
        MyList1,
        MyList2
    }
}
