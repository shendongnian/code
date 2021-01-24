    public IEnumerable<OrderModel> Parse(string[] input)
	{
		return
			(input ?? throw new ArgumentNullException(nameof(input)))
			.Select(orderModel =>
			{
				var items = orderModel.Split(";");
				if (items.Length != 4)
				{
					throw new ArgumentException();
				}
				return new OrderModel()
				{
					//filling objects
					ManagerSurname = items[1],
					ItemName = items[2],
                    ...
				};
			}).Where(orderModel =>  //Any);
	}
