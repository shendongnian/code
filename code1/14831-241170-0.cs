    public class Template {
        static Regex TAG_RE = new Regex(@"\{!(\w+)!}");
        public Template(object item) {
            this.item = item;
        }
        private string resolver(Match match) {
            string tag = match.Group[1];
            if (tag == "MyProperty") {
                return item.MyProperty.toString();
            }
            return "";
        }
        public string translate(string text) {
            return TAG_RE.Replace(text, new MatchEvaluator(this.resolver));
        }
    }
