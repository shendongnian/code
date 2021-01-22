		public class DisplayOrderAttribute : Attribute
		{
			private int order;
			public DisplayOrderAttribute(int order)
			{
				this.order = order;
			}
			public int Order
			{
				get { return order; }
			}
		}
