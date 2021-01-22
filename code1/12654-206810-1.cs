    // Make a SecureString
    SecureString sPassphrase = new SecureString();
    Console.WriteLine("Please enter your passphrase");
    ConsoleKeyInfo input = Console.ReadKey(true);
    while (input.Key != ConsoleKey.Enter)
    {
       sPassphrase.AppendChar(input.KeyChar);
       Console.Write('*');
       input = Console.ReadKey(true);
    }
    sPassphrase.MakeReadOnly();
    
    // Recover plaintext from a SecureString
    // Marshal is in the System.Runtime.InteropServices namespace
    try {
       IntPtr ptrPassphrase = Marshal.SecureStringToBSTR(sPassphrase);
       string uPassphrase = Marshal.PtrToStringUni(ptrPassphrase);
       // ... use the string ...
    }
    catch {
       // error handling
    } 
    finally {
       Marshal.ZeroFreeBSTR(ptrPassphrase);
    }
