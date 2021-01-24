	class ProductFilterProductIdEqualityComparer : IEqualityComparer<ProductFilter>
	{
		public bool Equals(ProductFilter x, ProductFilter y)
		{
			if (ReferenceEquals(x, y))
				return true;
			if (ReferenceEquals(x, null))
				return false;
			if (ReferenceEquals(y, null))
				return false;
			return x.ProductId == y.ProductId;
		}
		public int GetHashCode(ProductFilter obj) => obj.ProductId;
	}
