    class CovarianceWrapperExample
    {
    	class Person { }
    	class Employee : Person { }
    
    	void ProcessPeople(IList<Person> people) { /* ... */ }
    
    	void Foo()
    	{
    		List<Employee> employees = new List<Employee>();
    
    		// cannot do:
    		ProcessPeople(employees);
    
    		// can do:
    		ProcessPeople(new CovariantListWrapper<Person, Employee>(employees));
    	}
    }
