    class Program
    {
       public class Obj
       {
           public String name;
           public Obj Clone()
           {
               return this.MemberwiseClone() as Obj;
           }
       }
       static void Main(string[] args)
       {
           LinkedList<Obj> data = new LinkedList<Obj>();
           Obj temp = new Obj();
           temp.name = "ABC";
           data.AddLast(temp);
           Obj tempCopy = temp.Clone();
           tempCopy.name = "DEF";
           data.AddLast(tempCopy);
           foreach (Obj myClass in data)
           {
               Console.WriteLine(myClass.name);
           }
           Console.ReadKey();
       }
    }
