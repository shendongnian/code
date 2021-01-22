		[Fact]
		public void CantDecrementBasketLineQuantityBelowZero()
		{
			var o = new Basket();
			var p = new Product {Id = 1, NetPrice = 23.45m};
			o.AddProduct(p, 1);
			Assert.Throws<BusinessException>(() => o.SetProductQuantity(p, -3));
		}
