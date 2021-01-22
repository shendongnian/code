    Dictionary listOfClasses <long, TypeA>;
    Dictionary listOfTypeBClasses <string, TypeB>;
    
    TypeA newOject = TypeAFactory.Create();
    
    if(newObject is TypeB)
    {
    TypeB objB = newObj as TypeB;
    listOfTypeBClasses[objB.SomeString] = objB;
    }
    
    
