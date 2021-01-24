    public class Difficulty
    {
	    public int Fractional;
	    public int ArtistMax;
	
	    public Difficulty()
	    {
		    PopulateDifficultyWithDefaultData();
	    }
	
	    public Difficulty(int fractional, int artistmax)
	    {
		    this.Fractional = fractional;
		    this.ArtistMax = artistmax;
	    }
	
	    public void PopulateDifficultyWithDefaultData()
        {
		    this.Fractional = 3,
		    this.ArtistMax = 30
	    }
    }
    public class DifficultyList
    {
	    public List<Difficulty> QuestionDifficultyList = new List<Difficulty>();
	
	    public void AddDifficulty()
	    {
		    QuestionDifficultyList.Add(new Difficulty());
	    }
	
	    public void AddDifficulty(int fractional, int artistmax)
        {
		    QuestionDifficultyList.Add(new Difficulty(fractional, artistmax));
	    }
    }
