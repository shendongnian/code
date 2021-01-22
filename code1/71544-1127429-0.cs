    public static void Main()
    {
      // The variable name is misleading, because it is an integer, not a pointer
      int ptr1 = 0;
      // This is a pointer, and it is initialised with the address of ptr1 (@ptr1)
      // so it points to prt1.
      int* ptr2 = &ptr1;
      // This assigns to the int variable that ptr2 points to (*ptr2,
      // it now points to ptr1) the value of 220
      *ptr2 = 220;
      // Therefore ptr1 is now 220, the following line should write '220' to the console
      Console.WriteLine(ptr1);
    }
