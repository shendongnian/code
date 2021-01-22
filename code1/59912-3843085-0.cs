    [TestMethod]
    public void AccountRepository_ThrowsExceptionIfFileisCorrupt()
    {
         var file = File.Create("Accounts.bin");
         file.WriteByte(1);
         file.Close();
            
         IAccountRepository repo = new FileAccountRepository();
         TestHelpers.AssertThrows<SerializationException>(()=>repo.GetAll());            
    }
