        private Dictionary<string, string> _correctAnswerLookup;
        public Form1()
        {
            InitializeComponent();
            _correctAnswerLookup = GetCorrectAnswerByQuestionLookup();
        }
        private Dictionary<string, string> GetCorrectAnswerByQuestionLookup()
        {
            Dictionary<string, string> correctAnswerLookup = new Dictionary<string, string>(StringComparer.OrdinalIgnoreCase);
            using (SqlConnection connection = new SqlConnection(connectionString))
            {
                SqlCommand cmd = new SqlCommand("select QuestionId, Answer from Questions", connection);
                try
                {
                    connection.Open();
                    var reader = cmd.ExecuteReader();
                    while (reader.Read())
                    {
                        string questionId = (string)reader["QuestionId"];
                        string answer = (string)reader["Answer"];
                        if (!correctAnswerLookup.ContainsKey(questionId))
                        {
                            correctAnswerLookup.Add(questionId, answer);
                        }
                    }
                }
                catch (Exception e)
                {
                    // your exception handling
                }
            }
            return correctAnswerLookup;
        }
