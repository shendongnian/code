    public class Layout {
               private string start_bold = "[B]";
               private string end_bold = "[/B]";
               private string start_italics = "[I]";
               private string end_italics = "[/I]";
               
               public Layout(string formattype, int siteid)
               {
               //get format type logic here
               //if(formattype.ToLower() =="html")
               //{ . . . do something . . . }
               //call XML Doc for specific site, based upon formattype
                start_bold = Value.From.XML["bold_start"];
                end_bold = Value.From.XML["bold_end"];
               //Sorry, can't write XML document parsing code off the top of my head
               }          
               public string bold(this string x) {
                   return start_bold + x + end_bold;
               }
               public string italics(this string x) {
                   return start_italics + x+ end_italics;
               }
             
              
            }
    Layout l = new Layout("html", siteid);
    string s = String.Format("Output of {0} with number {1}, 
                              ValueToBeBoldAsAstring.bold(),
                              ValueToBeItalicAsAstring.italic());
