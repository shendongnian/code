    Predicate<int> IsPositivePred =	i => i > 0;
    Func<int,bool> IsPositiveFunc =	i => i > 0;
    
    new []{2,-4}.Where(i=>IsPositivePred(i)); //Wrap again
    
    new []{2,-4}.Where(IsPositivePred);  //Compile Error
    new []{2,-4}.Where(IsPositiveFunc);  //Func as Parameter
