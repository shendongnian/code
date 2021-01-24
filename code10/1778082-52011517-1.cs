	class a
	{
		public string Prop { get; set; }
	}
	class b
	{
		public DateTime Prop { get; set; }
	}
	class c
	{
		public string Prop2 { get; set; }
	}
	class Validator<T> : AbstractValidator<T>
	{
		public Validator()
		{
			this.Apply<T, string>("Prop", r => r.NotEmpty().WithMessage("Prop is required"));
		}
	}
	
	Console.WriteLine(new Validator<a>().Validate(new a { Prop = "AAA" }));
	Console.WriteLine(new Validator<a>().Validate(new a()));
	Console.WriteLine(new Validator<b>().Validate(new b { Prop = DateTime.Now }));
	Console.WriteLine(new Validator<c>().Validate(new c { Prop2 = "AAA" }));
	Console.WriteLine(new Validator<c>().Validate(new c { Prop2 = "AAA" }));
	
