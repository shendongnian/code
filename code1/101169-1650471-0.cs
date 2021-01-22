    public class Question
    {
        public Guid ID { get; set; }
        public int Number { get; set; }
        public QuestionType Type { get; set; }
        public string Content { get; set; }
        public Section Section { get; set; }
        public IList<Answer> Answers { get; set; }
    
        private IQuestionRenderer renderer;
        public RenderHtml()
        {
             if (renderer == null)
             {
                  QuestionRendererFactory.GetRenderer(Type);
             }
             renderer.Render(this);
        }
    }
    interface IQuestionRenderer
    {
        public Render(Question question);
    }
    public QuestionRendererA : IQuestionRenderer
    {
        public Render(Question question)
        {
             // Render code for question type A
        }
    }
    public QuestionRendererB : IQuestionRenderer
    {
        public Render(Question question)
        {
             // Render code for question type B
        }
    }
    public QuestionRendererFactory
    {
        public static IQuestionRenderer GetRenderer(QuestionType type)
        {
            // Create right renderer for question type
        }
    }
