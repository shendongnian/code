    List <Person> _list = new List <Person> ();
    // .... add lots of items
    var personToRemove = new Person {
      age = 99, grade = 7,
    };
    _list.Add(new Person {
      age = 99, grade = 7
    });
    _list.Add(new Person {
      age = 99, grade = 7
    });
    _list.Add(new Person {
      age = 99, grade = 8
    });
    _list.Add(new Person {
      age = 100, grade = 8
    });
    
    var result = _list.Where(a => a.age != personToRemove.age || a.grade != personToRemove.grade);
 
