    class Service {
        Session session; // could be injected by DI
        ...
        IPerson p = (IPerson) session.load( 50 );
    }
