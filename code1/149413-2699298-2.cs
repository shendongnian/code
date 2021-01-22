       Full example
namespace Test
{
    [TriLLi("11")]
    class Program
    {
        static void Main(string[] args)
        {
        }
    }
    class TriLLi : Attribute
    {
        public TriLLi(string ip)
        {
            if(!ip.Equals("10"))
                throw new Exception("You are not allowed to acces this method");
        }
    }
}
