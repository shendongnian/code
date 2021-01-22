    public static Thing withConnection(string connectionString) {
        Thing t = new Thing();
        t.doSomethingWithConnectionString(connection);
        return t;
    }
    public static Thing withFilename(string filename) {
        Thing t = new Thing();
        t.doSomethingWithFilename(filename);
        return t;
    }
    private Thing() {
        /* Make this private to clear things up */
    }
