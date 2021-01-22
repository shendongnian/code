    public static void Main()
    {
        if (new WindowsPrincipal(WindowsIdentity.GetCurrent()).IsInRole(WindowsBuiltInRole.Administrator))
        {
            Console.WriteLine("I am an admin.");
        }
    }
}
