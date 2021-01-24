        [TestMethod]
        public void Test_EditPrice()
        {
            // Arrange
            var data = new List<Book>
            {
                new Book(1, "Wuthering Heights", "Emily Brontë", "Classics", 7.99, 5)
            }.AsQueryable();
            var mockSet = new Mock<DbSet<Book>>();
            mockSet.As<IQueryable<Book>>().Setup(m => m.Provider).Returns(data.Provider);
            mockSet.As<IQueryable<Book>>().Setup(m => m.Expression).Returns(data.Expression);
            mockSet.As<IQueryable<Book>>().Setup(m => m.ElementType).Returns(data.ElementType);
            mockSet.As<IQueryable<Book>>().Setup(m => m.GetEnumerator()).Returns(data.GetEnumerator());
            var mockContext = new Mock<BookContext>();
            mockContext.Setup(c => c.Books).Returns(mockSet.Object);
            // Act
            var service = new BookStore(mockContext.Object);
            var books = service.GetAllBooks();
            service.EditPrice(1, 5.99);
            // Assert
            Assert.AreEqual(data.Count(), books.Count);
            Assert.AreEqual("Wuthering Heights", books[0].Title);
            Assert.AreEqual(5.99, books[0].Price);
        }
