    You have escope problem.
    You need to declara the variable outside the if statement.  
    
    If (){
    
    Code and variables that only exist here can only run here 
    //This method have to run here
    
    Real_Sex.Characteristics();
    Have to run here
    }
    Else {
    Same here...
    }
    Or you can make a dynamic variable outside the scope
    
   
    Console.WriteLine("Are you a boy or a girl?"); string sex = Console.ReadLine();
                dynamic real_sex;
                Console.WriteLine(sex); 
            while ((sex != ("boy")) && (sex != ("girl"))) 
        { 
        Console.WriteLine("That is not a valid sex. Please answer the question again."); 
            sex = Console.ReadLine(); }
             if (sex == "boy") {
             Console.WriteLine("You are a boy");
              real_sex = new Boy 
            { Firstname = "George", 
        Secondname = "Smith" }; 
        } 
            else if(sex == "girl") 
        { 
            Console.WriteLine("You are a girl"); 
                 real_sex = new Girl
             { Firstname = "Charlotte", 
            Secondname = "Smith" }; 
        }
             real_sex.Characteristics();
