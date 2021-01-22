      static void Main(string[] args)
      {
         Source item1 = new Source(2, 3, 4);
         Destination item2 = Copy(item1);
         Console.WriteLine(string.Format("X: {0}\nY: {1}", item2.X, item2.Y));
         Console.ReadKey();
      }
      static Destination Copy(Source copy)
      {
         Destination ret = new Destination();
         foreach (PropertyInfo pi in copy.GetType().GetProperties())
         {
            PropertyInfo pi2 = ret.GetType().GetProperty(pi.Name);
            if (pi2 != null)
            {
               pi2.SetValue(ret, pi.GetValue(copy, null), null);
            }
         }
         return ret;
      }
