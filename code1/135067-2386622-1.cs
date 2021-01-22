    class Service {
        Session session; // could be injected by DI
        ...
        Person p = (Person) session.load( typeof(Person), 50 );
    }
