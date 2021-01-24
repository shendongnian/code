    FieldInfo field = typeof(WindowsService.Program.DecryptFileToFile).GetField("<field name>", BindingFlags.Static | BindingFlags.Public | BindingFlags.NonPublic);
    byte[] array = (byte[])field.GetValue(null);
    foreach (byte value in array)
    {
        Console.Writeline("0x{0:X2}", value);
    }
