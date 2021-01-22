    public interface IEmployee {
        void DoSomething();
    }
    // assume Manager and Employee both implement IEmployee
    IEmployee ie = new Manager();
    ie.DoSomething();    // calls Manager.DoSomething()
    ie = new Employee();
    ie.DoSomething();    // calls Employee.DoSomething()
