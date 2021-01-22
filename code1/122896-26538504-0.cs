    public interface IView {
        Control Year { get; }
    }
    public Form : IView {
        public Control Year { get { return uxYear; } } //numeric text box or whatever
    }
