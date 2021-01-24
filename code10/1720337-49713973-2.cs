    class User
    {
        public string Name { get; set; }
    }
    Expression<Func<string, bool>> exp = s => s.Equals("Jack");
    Expression<Func<User, string>> nameAccessor = u => u.Name;
    var newExp = exp.ReplaceParameter(nameAccessor);   // u => u.Name.Equals("Jack")
