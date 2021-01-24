	public class Program
	{
		public static void Main()
		{
			//setup our test data
			var textBox1 = new TextBox("Max1");
			var textBox2 = new TextBox("Max2");
			var textBox3 = new TextBox("Max3");
			var textBox4 = new TextBox("Max4");
			//demo using anonymous objects (NB: property names must be known at compile time)
			var data = new object[] {
				new {Name1 = textBox1.Text}
				,new {Name2 = textBox2.Text}
				,new {Name3 = textBox3.Text}
				,new {Name4 = textBox4.Text}
			};
			Console.WriteLine( JsonConvert.SerializeObject(data, Formatting.Indented));
			//demo using a dictionary
			var textBoxes = new [] {textBox1, textBox2, textBox3, textBox4};
			var dict = new Dictionary<string,string>();
			for (var i = 0; i< textBoxes.Length; i++) 
			{
				dict.Add(string.Format("Name{0}", i+1), textBoxes[i].Text );
			}
			Console.WriteLine("[" + string.Join(",", dict.Select( e => string.Format("{{\"{0}\": \"{1}\"}}", e.Key.Replace("\"","\"\""), e.Value.Replace("\"","\"\"") ) )) + "]"); //based on https://stackoverflow.com/questions/5597349/how-do-i-convert-a-dictionary-to-a-json-string-in-c/5597628#5597628
		}
	}
	//dummy class	
	public class TextBox 
	{
		public TextBox(string text){Text = text;}
		public string Text{get;private set;}
	}
