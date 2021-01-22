using(DirectoryEntry groupEntry = new DirectoryEntry("WinNT://./Administrators,group"))
{
    foreach(object member in (IEnumerable) groupEntry.Invoke("Members"))
    {
        using(DirectoryEntry memberEntry = new DirectoryEntry(member))
        {
            Console.WriteLine(memberEntry.Path);
        }
    }
}
