    public void Inserir(Order order)
	{
		order.Code = new SequenceRepository(_database).GetSequenceValue("orderSequence");
		_collection.InsertOne(order);
	}
