        [Test]
        public void Test_ExpectCallsInOrder()
        {
            var mockCreator = new MockRepository();
            _mockChef = mockCreator.DynamicMock<Chef>();
            _mockInventory = mockCreator.DynamicMock<Inventory>();
            mockCreator.ReplayAll();
            _bakery = new Bakery(_mockChef, _mockInventory);
            
            using (mockCreator.Ordered())
            {
                _mockInventory.Expect(inv => inv.IsEmpty).Return(false);
                _mockChef.Expect(chef => chef.Bake(CakeFlavors.Pineapple, false));
            }
            
            _bakery.PleaseDonate(OrderForOnePineappleCakeNoIcing);
            _mockChef.VerifyAllExpectations();
            _mockInventory.VerifyAllExpectations();
        }
