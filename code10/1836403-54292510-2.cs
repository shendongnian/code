    public string GetConstNameByValue<T>(string constValue) =>
               typeof(T)
                    // Gets all public and static fields
		            .GetFields(BindingFlags.Static | BindingFlags.Public)
                    // IsLiteral determines if its value is written at 
                    //   compile time and not changeable
                    // IsInitOnly determine if the field can be set 
                    //   in the body of the constructor
                    // for C# a field which is readonly keyword would have both true 
                    //   but a const field would have only IsLiteral equal to true
		            .Where(f => f.IsLiteral && !f.IsInitOnly)
		            .FirstOrDefault(f => f.GetValue(null) == constValue)
		            ?.Name;
