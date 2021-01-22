    public class Service : IService
    {
        private readonly IFormService form;
        public Service(IFormService form)
        {
            this.form = form
        }
        public string PrintMessage(string message)
        {
            this.form.Text = message;
        }
    }
