      [TestMethod]
      public void TestLastModifiedTimeStamps()
      {
         var tempFile = Path.GetTempFileName();
         var lastModified = File.GetLastWriteTime(tempFile);
         using (new FileStream(tempFile, FileMode.Create, FileAccess.Write, FileShare.None))
         {
            
         }
         Assert.AreNotEqual(lastModified, File.GetLastWriteTime(tempFile));
      }
