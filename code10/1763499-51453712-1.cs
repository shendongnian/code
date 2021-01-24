    class Animal {}
    class Tiger : Animal {}
    
    interface ICage { 
        Animal GetAnimal(); }
    
    class TigerCage : ICage { 
        //Won’t compile
        public Tiger GetAnimal() => 
            new Tiger(); }
