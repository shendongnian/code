    static bool IsInRange (int input)
    {
        return input >= 0 && input <= 100;
    }
	static int GetScore (int studentIndex, int intscoreIndex)
	{
		int parsedScore;
		var isValid = false;
		while (!isValid)
		{
			Console.WriteLine("Enter score: {0} for student: {1}", scoreIndex + 1, studentIndex + 1);
			var score = Console.ReadLine();
			if (IsNumeric(score))
			{
				parsedScore = Convert.ToInt32(score);
                if (IsInRange(parsedScore))
                {
					isValid = true;
				}
				else
				{
                    Console.WriteLine(string.Empty);
                    Console.WriteLine("Please enter a value between 0 and 100");
                }			
			}
			else
			{
				Console.WriteLine();
				Console.WriteLine("Please enter a numeric value.");
			}
		}
		return parsedScore;
	}
.
    for (int studentIndex = 0; studentIndex < studentCount; studentIndex++)
    {
        for (int scoreIndex = 0; scoreIndex < scoreCount; scoreIndex++)
        {                
			studentScores[studentIndex, scoreIndex] = GetScore(studentIndex, scoreIndex);
        }
    }
	
	
