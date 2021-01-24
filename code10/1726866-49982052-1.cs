    public class DialogueSuper : MonoBehaviour
    {
        // Way 1: Property Injection
        public IChoiceHandler ChoiceHandler
        {
            get; set;
        }
        // Way 2: Constructor injection
        private IChoiceHandler _choiceHandler;
        private DialogueSuper() : base()
        {
        }
        public DialogueSuper(IChoiceHandler choiceHandler)
        {
            _choiceHandler = choiceHandler;
        }
        // Way 3: Method Injection
        public void end(IChoiceHandler choiceHandler)
        {
            // For way 1
            ChoiceHandler.Next();
            // For way 2
            _choiceHandler.Next();
            // For way 3
            choiceHandler.Next();
        }
    }
