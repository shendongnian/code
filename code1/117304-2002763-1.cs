    static void Main(string[] args)
    {
        using (LdapConnection connect = CreateConnection("localhost"))
        {
            using (ChangeNotifier notifier = new ChangeNotifier(connect))
            {
                //register some objects for notifications (limit 5)
                notifier.Register("dc=dunnry,dc=net", SearchScope.OneLevel);
                notifier.Register("cn=testuser1,ou=users,dc=dunnry,dc=net", SearchScope.Base);
 
                notifier.ObjectChanged += new EventHandler<ObjectChangedEventArgs>(notifier_ObjectChanged);
 
                Console.WriteLine("Waiting for changes...");
                Console.WriteLine();
                Console.ReadLine();
            }
        }
    }
 
    static void notifier_ObjectChanged(object sender, ObjectChangedEventArgs e)
    {
        Console.WriteLine(e.Result.DistinguishedName);
        foreach (string attrib in e.Result.Attributes.AttributeNames)
        {
            foreach (var item in e.Result.Attributes[attrib].GetValues(typeof(string)))
            {
                Console.WriteLine("\t{0}: {1}", attrib, item);
            }
        }
        Console.WriteLine();
        Console.WriteLine("====================");
        Console.WriteLine();
    }
