    static readonly string template =
        @"internal class {ClassName} : IHuman 
		  {
              // bunch of private fields here
              private int age = {Age};
              public int Age
              {
                  get { return age; }
                  set
                  {
                      age = value;
                      OnPropertyChanged(nameof(Age));
                  }
              }
              // Other properties and members
		  }";
