    using Microsoft.AspNetCore.DataProtection;
    static class Program
    {
        static void Main()
        {
            var dataProtectionProvider = DataProtectionProvider.Create("Test App");
            var protector = dataProtectionProvider.CreateProtector("Program.No-DI");
            var plainText = "ABCDEFGH";
            var protectedText = protector.Protect(plainText);
        }
    }
