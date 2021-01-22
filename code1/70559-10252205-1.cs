static void Main(string[] args)
{
ArrayList list = new ArrayList();
int i = 0;
while (true)
{
using(byte newBt = new byte[1024 * 1024 * 10])
{
                list.Add(newBt); // 10 MB`
                i += 10;`
                Console.WriteLine(i);`
}
}
}
