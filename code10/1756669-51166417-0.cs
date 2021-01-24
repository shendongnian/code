            [TestMethod]
    		public void GetDataTest()
    		{
    			Order order = null;
    
    			var c1 = new Class1(order);
    
    			Assert.IsFalse(c1.GetData().Result);
    		}
