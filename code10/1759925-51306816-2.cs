	public class UniProgram
	{
		public string Programme { get; set; }
		public IList<Degree> Degrees { get; } = new List<Degree>();
		
		public UniProgram(string programme, params string[] degree)
		{
			this.Programme = programme;
			foreach (var name in degree)
				this.Degrees.Add(new Degree(name));
		}
	}
