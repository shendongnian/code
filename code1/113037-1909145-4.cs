       class Program {
         static void Main(string[] args)
         {
           Source item1 = new Source(2, 3, 4);
           Destination item2 = new Destination(item1, ContinueCopy);
           Console.WriteLine(string.Format("X: {0}\n Y: {1}", item2.X, item2.Y));
           Console.ReadKey();
         }
         public static bool ContinueCopy(string name, Type type)
         {
            if (name == "X" && type == typeof(int)) return false;
            return true;
         }
      }
      public class Source {
         public Source() { }
         public Source(int x, int y, int z)
         {
           myX = x;
           myY = y;
           myZ = z;
         }
         private int myX;
         public int X
         {
           get { return myX; }
           set { myX = value; }
         }
         private int myY;
         public int Y
         {
           get { return myY; }
           set { myY = value; }
         }
         private int myZ;
         public int Z
         {
           get { return myZ; }
           set { myZ = value; }
         }
      }
      public class Destination {
         public delegate bool ContinueCopyCallback(string propertyName, Type propertyType);
         public Destination() : this(0,0) { }
         public Destination(int x, int y)
         {
            myX = x;
            myY = y;
         }
         public Destination(Source copy) : this(copy, null) { }
         public Destination(Source copy, ContinueCopyCallback callback)
         {
            foreach (PropertyInfo pi in copy.GetType().GetProperties())
            {
               PropertyInfo pi2 = this.GetType().GetProperty(pi.Name);
               if ((callback == null || (callback != null && callback(pi.Name, 
                  pi.PropertyType))) && pi2 != null && pi2.GetType() == pi.GetType())
               {
                  pi2.SetValue(this, pi.GetValue(copy, null), null);
               }
            }
         }
         private int myX;
         public int X
         {
            get { return myX; }
            set { myX = value; }
         }
         private int myY;
         public int Y
         {
            get { return myY; }
            set { myY = value; }
         }
     }
