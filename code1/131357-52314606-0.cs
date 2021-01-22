        class Person
        {
            public string Name { get; set; }
            public int Age { get; set; }
            public List<string> Friends { get; set; }
        }
        static void Main(string[] args)
        {
            Template.RegisterSafeType(typeof(Person), new string[]
                {
                    nameof(Person.Name),
                    nameof(Person.Age),
                    nameof(Person.Friends),
                });
            Template template = Template.Parse(
	@"<h1>hi {{name}}</h1> 
	<p>You are{% if age > 42' %} old {% else %} young{% endif %}.</p>
	<p>You have {{ friends.size }} friends:</p>
	{% assign sortedfriends = friends | sort %}
	{% for item in sortedfriends -%}
	  {{ item | escape }} <br />
	{% endfor %}
	
	");
            string output = template.Render(
                Hash.FromAnonymousObject(
                    new Person()
                    {
                        Name = "James Bond",
                        Age = 42,
                        Friends = new List<string>()
                        {
                            "Charlie",
                            "<TagMan>",
                            "Bill"
                        }
                    } ));
            Console.WriteLine(output);
	
	/* The output will be: 
	
	<h1>hi James Bond</h1>
	<p>You are young.</p>
	<p>You have 3 friends:</p>
	
	  &lt;TagMan&gt; <br />
	  Bill <br />
	  Charlie <br />             
	
	*/
        }
