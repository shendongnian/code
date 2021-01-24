	void Main()
	{
		Test db = new Test();
		MyModel model = new MyModel();
		model.UserLanguages = (from u in db.Users
	                    join l in db.Languages on u.LanguageId equals l.Id
	                    select new {UserName = u.LastName, Language = l.Name})
						.Select(x=> {
							dynamic expando = new System.Dynamic.ExpandoObject();
							expando.UserName = x.UserName;
							expando.Language = x.Language;
							return (System.Dynamic.ExpandoObject)expando;
						})
						.ToList();
						
        Console.WriteLine(((dynamic)model.UserLanguages[0]).UserName);
	}
	
	public class Test
	{
		public Test()
		{
			Users = new List<User>(){
				new User(){
					LanguageId = 1,
					LastName = "Hello"
				}
			};
			Languages = new List<Language>(){
				new Language(){
					Id = 1,
					Name = "Test"
				}
			};
		}
		public List<User> Users{get;set;}
		public List<Language> Languages{get;set;}
	}
	
	public class User
	{
		public int LanguageId{get;set;}
		public string LastName{get;set;}
		
	}
	
	public class Language
	{
		public int Id{get;set;}
		public string Name{get;set;}
	}
	
	public class MyModel
	{
		public List<System.Dynamic.ExpandoObject> UserLanguages { get; set; }
	}
	
