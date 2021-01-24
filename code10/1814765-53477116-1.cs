        public class MongoDBconfig
        {
            public string MongoDBConnection { get; set; }
        }
    
        public class DatabaseHelper
        {
            public static string connstring { get; private set; }
            public DatabaseHelper(IOptions<MongoDBconfig> Configuration)
            {
                connstring = Configuration.Value.MongoDBConnection;
            }
    
    
            public static IMongoDatabase QuizDB { get; } = GetDatabase("QuizEngine");
            public static IMongoCollection<Quiz> QuizCol { get; } = GetQuizCollection();
    
    
            public static MongoClient GetConnection()
            {
    
                return new MongoClient(connstring);
            }
    
            public static IMongoDatabase GetDatabase(string database)
            {
    
                MongoClient conn = DatabaseHelper.GetConnection();
                return conn.GetDatabase(database);
            }
    
            public static IMongoCollection<Quiz> GetQuizCollection()
            {
                return DatabaseHelper.QuizDB.GetCollection<Quiz>("Quizzes");
            }
        }
