	public PersonDto Data
	{
		get
		{
			return new PersonDto
			{
				FirstName = this.FirstNameTextBox.Text,
				LastName = this.LastNameTextBox.Text,
				// ...
			}
		}
	}
