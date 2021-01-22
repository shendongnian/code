	void Main()
	{
		void checkedCode()
		{
			try 
			{
				foo();
			}
			catch (Exception ex)
			{
				recover();
				return;
			}
			// ElseCode here
		}
		checkedCode();
	}
