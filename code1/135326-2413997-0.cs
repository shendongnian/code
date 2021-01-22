    public class Foo
    {
        public event EventHandler Bar;
        public string BarName
        {
            get
            {
                return this.GetEventName(() => this.Bar);
            }
        }
        private string GetEventName(Expression<Func<EventHandler>> expression)
        {
            return (expression.Body as MemberExpression).Member.Name;
        }
    }
