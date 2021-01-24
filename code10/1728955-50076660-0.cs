    public class SearchPage : Page<_>
    {
        [FindById("search-query")]
        [PressEnter] // Adds trigger.
        public TextInput<_> Query { get; private set; }
    }
