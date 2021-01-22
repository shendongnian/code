    using Microsoft.VisualStudio.TestTools.UnitTesting;
    using System.Security;
    
    namespace SecurityUtils.Test
    {
        [TestClass]
        public class StringsTest
        {
            [TestMethod]
            public void DecryptSecureStringWithFunc()
            {
                // Arrange
                var secureString = new SecureString();
    
                foreach (var c in "UserPassword123".ToCharArray())
                    secureString.AppendChar(c);
    
                secureString.MakeReadOnly();
    
                // Act
                var result = Strings.DecryptSecureString<bool>(secureString, (password) =>
                {
                    return password.Equals("UserPassword123");
                });
    
                // Assert
                Assert.IsTrue(result);
            }
    
            [TestMethod]
            public void DecryptSecureStringWithAction()
            {
                // Arrange
                var secureString = new SecureString();
    
                foreach (var c in "UserPassword123".ToCharArray())
                    secureString.AppendChar(c);
    
                secureString.MakeReadOnly();
    
                // Act
                var result = false;
    
                Strings.DecryptSecureString(secureString, (password) =>
                {
                    result = password.Equals("UserPassword123");
                });
    
                // Assert
                Assert.IsTrue(result);
            }
        }
    }
