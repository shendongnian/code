    //ActiveDirectorySearch1
    //Displays all computer names in an Active Directory
    using System;
    using System.DirectoryServices; 
    namespace ActiveDirectorySearch1
    {
    class Class1
    {
    static void Main (string[] args)
    {
    //Note : microsoft is the name of my domain for testing purposes.
    DirectoryEntry entry = new DirectoryEntry(LDAP://microsoft);
    DirectorySearcher mySearcher = new DirectorySearcher(entry);
    mySearcher.Filter = ("(objectClass=computer)");
    Console.WriteLine("Listing of computers in the Active Directory"); 
    Console.WriteLine("============================================"); foreach(SearchResult resEnt in mySearcher.FindAll())
    { 
    Console.WriteLine(resEnt.GetDirectoryEntry().Name.ToString()); }
    Console.WriteLine("=========== End of Listing ============="); 
    }
    }
    }
