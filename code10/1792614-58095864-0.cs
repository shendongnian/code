    public class Answer
    {
        public string Text;
        public string Category;
        public int ViewsCount;
    }
    
    public class AnswersCollection
    {
        private readonly List<Answer> _answers = new List<Answer>();
    
        /// <summary>
        /// to init data
        /// </summary>
        public void AddAnswer(string text, string category)
        {
            _answers.Add(new Answer {Text = text, Category = category, ViewsCount = 0});
        }
    
        public string GetNoViewedRandomAnswer(bool setViewed = true)
        {
            var some = _answers.Where(a => a.ViewsCount == 0)
                .OrderBy(_ => Guid.NewGuid()) // to randomize collection ordering
                .FirstOrDefault();
            if (some != null && setViewed) some.ViewsCount++;
            return some.Text;
        }
    
        public string[] GetViewedCategories() =>
            _answers.Where(a => a.ViewsCount > 0).Select(a => a.Category).ToArray();
    
        public string[] GetViewedAnswers() =>
            _answers.Where(a => a.ViewsCount > 0).Select(a => a.Text).ToArray();
    
        public System.Tuple<string, string>[] GetViewedAnswersWithCategory() =>
            _answers.Where(a => a.ViewsCount > 0).Select(a => Tuple.Create(a.Text, a.Category)).ToArray();
    }
