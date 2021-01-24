	public static void Main() {
		
		string json = @"{
                'data': {
                        'human': {
                            'name': 'Luke Skywalker',
                            'height': 5.6430448
                        }
                    }
                }
            ";
		dynamic varOfA = JsonConvert.DeserializeObject(json);
		string name = varOfA.data.human.name;
		Console.WriteLine(name); // Luke Skywalker		
		Person person = varOfA.data.human.ToObject<Person>();
		name = person.name; 
		Console.WriteLine(name); //Luke Skywalker
	}
	public class Person {
		public string name { get; set; }
		public double height { get; set; }
	}
