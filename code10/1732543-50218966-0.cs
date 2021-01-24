    interface IEmployee
    {
        void PayMe()
    }
    
    class Salaried : IEmployee 
    {
        void PayMe(int salary) { }
    }
    
    class Hourly : IEmployee
    {
        void PayMe(int rate, int hours) { }
    }
