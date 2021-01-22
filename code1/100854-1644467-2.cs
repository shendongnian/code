    public class xyz {
           private string start_bold = "[B]";
           private string end_bold = "[/B]";
           private string start_italics = "[I]";
           private string end_italics = "[/I]";
           private string _htmlFrag;
           
           public string bold(this) {
               return start_bold + this._htmlFrag + end_bold;
           }
           public string italics(this) {
               return start_italics + this._htmlFrag + end_italics;
           }
           public xyz(string htmlFragment)
           {
            this._thmlFrag = htmlFragment;
           }
        }
