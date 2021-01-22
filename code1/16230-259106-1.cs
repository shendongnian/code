    public class RegexAction {
        public Regex Pattern { get; private set; }
        public Action<string> Handler { get; private set; }
        public RegexAction(Regex pattern, Action<string> handler) {
            this.Pattern = pattern;
            this.Handler = handler;
        }
    }
    public static RegexAction[] HandlerTable = new RegexAction[] {
        new RegexAction(regex1, HandleFirstCase),
        new RegexAction(regex2, HandleSecondCase),
        new RegexAction(regex3, HandleThirdCase),
        // ...
    }
    foreach(RegexAction action in HandlerTable) {
        if (action.Match(query)) {
            action.Handler(query);
            break;
        }
    }
