    namespace RemoteDoc
    {
        public interface IDocumentation
        {
            // public functions you want to mock go here
            string GetDocumentation();
        }
    
        public partial class Documentation : IDocumentation {}
    }
