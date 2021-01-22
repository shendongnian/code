    public final class Database {
        static {
            try {
                Class.forName("com.example.jdbc.Driver");
            } catch (ClassNotFoundException e) {
                throw new ExceptionInInitializerError(e);
            }
        }
        private Database() {
            // No need to instantiate this class.
        }
        public static Connection getConnection() {
            DriverManager.getConnection("jdbc:example://localhost/dbname", "user", "pass");
        }
    }
