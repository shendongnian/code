Resharper -> windows -> IL Viewer
    int number = 234;
    unsafe 
    {
        // Assign the address of number to a pointer:
        int* p = &number;
        // Print the value of *p:
        System.Console.WriteLine("Value at the location pointed to by p: {0:X}", *p);
        // Print the address stored in p:
        System.Console.WriteLine("The address stored in p: {0}", (int)p);
    }
