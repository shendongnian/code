		void Main()
		{
			string keyToCheck = "description";
			var obj = new Super1();
			var dict = (from p in obj.Super
					   where p.dict != null && p.dict.Keys.Any(x=>x==keyToCheck)
					   select p.dict).Select(x=>x[keyToCheck]);
			Console.Write(dict);
		}
		
		public class Super1
		{
			public List<Test> Super { get; set; } = new List<Test>(){
				new Test(){ Id = 1, dict = new Dictionary<string,string>() {
					{"description","abc"},{"description1","1"},{"description2","2"},{"description3","3"}
				}},
				new Test(){ Id = 2, dict = new Dictionary<string,string>() {
					{"description","xyz"},{"description4","4"},{"description5","5"},{"description6","6"}
				}
			}};
		}
		
		public class Test
		{
		    public int Id { get; set; }
		
		    public Dictionary<string, string> dict { get; set; }
		}
