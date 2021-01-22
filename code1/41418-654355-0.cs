    public partial class Abbreviations : System.Web.UI.UserControl
    {
        private Dictionary<String, String> dictionary = DataHelper.GetAbbreviations();
        
        protected void Page_Load(object sender, EventArgs e)
        {
            string input = "This is just a little test of the memb. And another memb, but not amemba to see if it gets picked up. Deb of course should also be caught here.deb!";
            var regex = "\\b(?:" + String.Join("|", dictionary.Keys.ToArray()) + ")\\b";
            MatchEvaluator myEvaluator = new MatchEvaluator(GetExplanationMarkup);
            input = Regex.Replace(input, regex, myEvaluator, RegexOptions.IgnoreCase);
            litContent.Text = input;
        }
        private string GetExplanationMarkup(Match m)
        {
            return string.Format("<b title='{0}'>{1}</b>", dictionary[m.Value.ToLower()], m.Value);
        }
    }
