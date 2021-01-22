    using System;
    using System.DirectoryServices;
    
    class Class1
    {
        static void Main(string[] args)
        {
        try
            {
    	 DirectoryEntry AD = new DirectoryEntry("WinNT://" + 
    	                     Environment.MachineName + ",computer");
    	 DirectoryEntry NewUser = AD.Children.Add("TestUser1", "user");
    	 NewUser.Invoke("SetPassword", new object[] {"#12345Abc"});
    	 NewUser.Invoke("Put", new object[] {"Description", "Test User from .NET"});
    	 NewUser.CommitChanges();
    	 DirectoryEntry grp;
    
    	 grp = AD.Children.Find("Guests", "group");
    	 if (grp != null) {grp.Invoke("Add", new object[] {NewUser.Path.ToString()});}
    	 Console.WriteLine("Account Created Successfully");
    	 Console.ReadLine();
    	}
        catch (Exception ex)
    	{
    	 Console.WriteLine(ex.Message);
    	 Console.ReadLine();
    
    	}
        }
    }
