    public class Question
    {
        public Guid ID { get; set; }
        public int Number { get; set; }
        public string Content { get; set; }
        public Section Section { get; set; }
        public IList<Answer> Answers { get; set; }
        public virtual string RenderHtml();
    }
    public class MultipleChoiceQuestion 
    {
        public string RenderHtml() { 
          // render a radio button
        }
    }
    public class MultipleAnswerQuestion 
    {
        public string RenderHtml() { 
          // render a radio button
        }
    }
