        public class Question
        {
            public string Id { get; set; }
            public static IEnumerable<Question> Extract(XElement questionsElement)
            {
                return questionsElement.Elements().Select(elem => new Question { Id = elem.Attribute("id").Value });
            }
        }
