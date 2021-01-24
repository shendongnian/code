        [TestMethod]
        public void IdentifyToken_Returns_UserWM_On_Successful_Request()
        {
            UserManager userManager = new UserManager();
            MD5Hasher passwordHasher = new MD5Hasher();
            IEnumerable<Claim> claims = new List<Claim>
            {
                new Claim(ClaimTypes.Email, "creditmaster@admin.com"),
                new Claim(ClaimTypes.Hash, passwordHasher.Encrypt("qW12345?"))
            };
            ClaimsIdentity identity = new ClaimsIdentity();
            identity.AddClaims(claims);
            var testResult = userManager.IdentifyToken(identity);
            Assert.AreEqual(typeof(UserWM), testResult.GetType());
        }
