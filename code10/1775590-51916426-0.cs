        public class ClsQuestions
        {
            // Parent ID to be referenced by children
            public int ID { get; set; }
            public string question { get; set; }
        }
    
        public class ClsOptions
        {
            // Parent question id of the option
            public int QuestionID { get; set; }
            public int optionid { get; set; }
            public string optionvalue { get; set; }
            public string optionlable { get; set; }
        }
