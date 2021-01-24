	private void button1_Click(object sender, EventArgs e)
	{
		var ingredients = new Dictionary<string, int>()
		{
			{ "Chocolate", int.Parse(QtyChocolate.Text) },
			{ "Vanilla", int.Parse(QtyVanilla.Text) },
			{ "Strawberry", int.Parse(QtyStrawberry.Text) },
			{ "Melon", int.Parse(QtyMelon.Text) },
			{ "Mint", int.Parse(QtyMint.Text) },
			{ "Marijuana", int.Parse(QtyMarijuana.Text) },
		}
		
		foreach (var ingredient in ingredients)
		{
			TableUpdate(ingredient.Key, ingredient.Value.ToString());
		}
	}
