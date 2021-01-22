	[Serializable()]
	public class LevelDefinition
	{
		public Vector3 PlayerStartPosition { get; set; }
		public string LevelName { get; set; }
		public List<Enemy> Enemies { get; set; }
		... etc
	}
