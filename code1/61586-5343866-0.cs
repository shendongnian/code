    dynamic  di = 20;
    dynamic ds = "sadlfk";
    var vi = 10;
    var vsTemp= "sdklf";
    
    Console.WriteLine(di.GetType().ToString());          //Prints System.Int32
    Console.WriteLine(ds.GetType().ToString());          //Prints System.String
    Console.WriteLine(vi.GetType().ToString());          //Prints System.Int32
    Console.WriteLine(vsTemp.GetType().ToString());      //Prints System.String
    
    **ds = 12;**   //ds is treated as string until this stmt now assigning integer.
    
    Console.WriteLine(ds.GetType().ToString());          **//Prints System.Int32**
    
    **vs = 12**; //*Gives compile time error* - Here is the difference between Var and Dynamic. var is compile time bound variable.
