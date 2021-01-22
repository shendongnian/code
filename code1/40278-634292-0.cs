    public static IEnumerable<TBase> ToBaseEnumerable<TBase, TDerived>( this IEnumerable<TDerived> items ) where TDerived : TBase {
        foreach( var item in items ) {
            yield return item;
        }
    }
    ...
    IEnumerable<Employee> employees = GetEmployees(); //Emplyoee derives from Person
    DoSomethingWithPersons( employees.ToBaseEnumerable<Person, Employee>() );
