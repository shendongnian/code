    public static class JsonContractExtensions
    {
        public static void ConfigurePerson(this JsonContract contract)
        {
			if (!typeof(Person).IsAssignableFrom(contract.UnderlyingType))
				return;
			var objectContract = contract as JsonObjectContract;
            if (objectContract == null)
                return;
            var property = objectContract.Properties.Where(p => p.UnderlyingName == nameof(Person.LastName)).Single();
			property.Converter = new AllCapsConverter();
        }
	}
