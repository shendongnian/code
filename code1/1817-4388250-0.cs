		List<MeuTeste> temp = new List<MeuTeste>();
		temp.Add(new MeuTeste(2, "ramster", DateTime.Now));
		temp.Add(new MeuTeste(1, "ball", DateTime.Now));
		temp.Add(new MeuTeste(8, "gimm", DateTime.Now));
		temp.Add(new MeuTeste(3, "dies", DateTime.Now));
		temp.Add(new MeuTeste(9, "random", DateTime.Now));
		temp.Add(new MeuTeste(5, "call", DateTime.Now));
		temp.Add(new MeuTeste(6, "simple", DateTime.Now));
		temp.Add(new MeuTeste(7, "silver", DateTime.Now));
		temp.Add(new MeuTeste(4, "inn", DateTime.Now));
		SortList(ref temp, SortDirection.Ascending, "MyProperty");
		private void SortList<T>(
		ref List<T> lista
		, SortDirection sort
		, string propertyToOrder)
		{
			if (!string.IsNullOrEmpty(propertyToOrder)
			&& lista != null
			&& lista.Count > 0)
			{
				Type t = lista[0].GetType();
				if (sort == SortDirection.Ascending)
				{
					lista = lista.OrderBy(
						a => t.InvokeMember(
							propertyToOrder
							, System.Reflection.BindingFlags.GetProperty
							, null
							, a
							, null
						)
					).ToList();
				}
				else
				{
					lista = lista.OrderByDescending(
						a => t.InvokeMember(
							propertyToOrder
							, System.Reflection.BindingFlags.GetProperty
							, null
							, a
							, null
						)
					).ToList();
				}
			}
		}
