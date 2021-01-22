        [TestMethod]
        public void MD5HashTest()
        {
            var hash1 = (new MD5CryptoServiceProvider()).ComputeHash(new System.Text.ASCIIEncoding().GetBytes("now is the time for all good men."));
            var hash2 = (new MD5CryptoServiceProvider()).ComputeHash(new System.Text.ASCIIEncoding().GetBytes("now is the time for all good men."));
            Assert.AreEqual(hash1, hash2);
        }
