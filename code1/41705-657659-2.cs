    Something some = new Something();
    some.Action(); //calls the regular Action
    ISomething isome = some;
    isome.Action(); //calls the ISomething.Action
    ((ISomething)some).Action(); //again, calls ISomething.Action
    
    Something2 some2 = new Something2();
    some2.Action();//compile error
    ((ISomething)some2).Action(); //calls ISomething.Action
    ((IsomethingElse)some2).Action(); // calls ISomethingElse.Action
