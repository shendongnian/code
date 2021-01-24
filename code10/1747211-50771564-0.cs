	void Main()
	{
		Dictionary<SpecialPoint, int> specialPoints = new Dictionary<SpecialPoint, int>()
		{
			{ SpecialPoint.STRENGTH, 5 },
			{ SpecialPoint.PERCEPTION, 5 },
			{ SpecialPoint.ENDURANCE, 5 },
			{ SpecialPoint.CHARISMA, 5 },
			{ SpecialPoint.INTELLIGENCE, 5 },
			{ SpecialPoint.AGILITY, 5 },
			{ SpecialPoint.LUCK, 5 },
		};
	
		AskSpecialPoint(specialPoints, SpecialPoint.STRENGTH);
		AskSpecialPoint(specialPoints, SpecialPoint.PERCEPTION);
		AskSpecialPoint(specialPoints, SpecialPoint.ENDURANCE);
		AskSpecialPoint(specialPoints, SpecialPoint.CHARISMA);
		AskSpecialPoint(specialPoints, SpecialPoint.INTELLIGENCE);
		AskSpecialPoint(specialPoints, SpecialPoint.AGILITY);
		AskSpecialPoint(specialPoints, SpecialPoint.LUCK);
	}
	
	private void AskSpecialPoint(Dictionary<SpecialPoint, int> specialPoints, SpecialPoint specialPoint)
	{
		int points = -1;
		do
		{
			Console.WriteLine("Current {0}: {1}. Adjust points: ", specialPoint.ToString(), specialPoints[specialPoint]);
		} while (!int.TryParse(Console.ReadLine(), out points));
		specialPoints[specialPoint] += points;
	}
	
	public enum SpecialPoint
	{
		STRENGTH,
		PERCEPTION,
		ENDURANCE,
		CHARISMA,
		INTELLIGENCE,
		AGILITY,
		LUCK,
	}
