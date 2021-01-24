    foreach (Param p in lst)
    {
        if(p is Param_Int){
            Param_Int param_Int = p as Param_Int;
            Console.WriteLine(param_Int.value);
        } else if (p is Param_Double){
            Param_Double param_Double = p as Param_Double;
            Console.WriteLine(param_Double.value);
        } else if (p is Param_String){
            Param_String param_String = p as Param_String;
            Console.WriteLine(param_String.value);
        }
    }
