    class Fruit {
     public int ID {get; set;}
    }
    
    class Apple : Fruit {
    // I want to call this ID also but it refers to a different ID than the base ID
     public int AppleID {get; set;}
    }
