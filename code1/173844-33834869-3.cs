    using System.Collections.Generic;
    using System.Linq;
    using NUnit.Framework;
    
    [TestFixture]
    public class SqlStringExtensionsTests
    {
        [Test]
        public void ValidateSql_InvalidSql_ReturnsErrorMessages()
        {
            // this example doesn't contain "," between the field names
            string invalidSql = "SELECT /*comment*/ " +
                "CustomerID AS ID CustomerNumber FROM Customers";
            IEnumerable<string> results = invalidSql.ValidateSql();
            Assert.AreNotEqual(0, results.Count());
        }
    
        [Test]
        public void IsValidSql_ValidSql_ReturnsTrue()
        {
            string validSql = "SELECT /*comment*/ " +
                "CustomerID AS ID, CustomerNumber FROM Customers";
            bool result = validSql.IsValidSql();
            Assert.AreEqual(true, result);
        }
    
        [Test]
        public void IsValidSql_InvalidSql_ReturnsFalse()
        {
            // this example doesn't contain "," between the field names
            string invalidSql = "SELECT /*comment*/ "+
                " CustomerID AS ID CustomerNumber FROM Customers";
            bool result = invalidSql.IsValidSql();
            Assert.AreEqual(false, result);
        }
    }
