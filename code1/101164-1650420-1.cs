    public class Question
    {
        public Guid ID { get; set; }
        public int Number { get; set; }
        public string Content { get; set; }
        public Section Section { get; set; }
        public IList<Answer> Answers { get; set; }
        public IRenderer Renderer { get; private set; }
    }
    public interface IRenderer {
        void RenderHtml(Question q);
    }
    public class MultipleChoiceRenderer : IRenderer
    {
        public string RenderHtml(Question q) { 
          // render a radio button
        }
    }
    public class MultipleAnswerRenderer: IRenderer
    {
        public string RenderHtml(Question q) { 
          // render checkboxes
        }
    }
