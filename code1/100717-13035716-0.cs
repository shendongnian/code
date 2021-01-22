        public class Content2
    {
        public virtual bool IsCheckedOut { get; protected set; }
        public virtual void CheckOut()
        {
            IsCheckedOut = true;
        }
        public virtual void CheckIn()
        {
            //Do Nothing for now as demonstrating false positive test.
        } 
    }
        [TestClass]
    public class Content2Test : Content2
    {
        [TestMethod]
        public void CheckOutSetsCheckedOutStatusToTrue()
        {
            this.CheckOut();
            Assert.AreEqual(true, this.IsCheckedOut); //Test works as expected
        }
        [TestMethod]
        public void CheckInSetsCheckedOutStatusToFalse()
        {
            this.IsCheckedOut = true;
            this.CheckIn();
            Assert.AreEqual(false, this.IsCheckedOut); //Test does not work as expected
        }
    }
