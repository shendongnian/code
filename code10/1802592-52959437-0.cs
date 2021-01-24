    public static void Main()
       {
          ObjectHandle handle = Activator.CreateInstance("PersonInfo", "Person");
          Person p = (Person) handle.Unwrap();
          p.Name = "Samuel";
          Console.WriteLine(p);
       }
