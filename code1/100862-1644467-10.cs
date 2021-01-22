    <site>
      <html>
         <style value="{~b}">[b]</style>
         <style value="{~~b}">[/b]</style> 
         <style value="{~i}">[i]</style>
         <style value="{~~i}">[/i]</style> 
      </html>
      <phpBBCode>
 
          ......
    public class Layout {
                   //private string start_bold = "[B]";
                   //private string end_bold = "[/B]";
                   //private string start_italics = "[I]";
                   //private string end_italics = "[/I]";
                   private string _stringtoformat;
                   public string StringToFormat {set{ _stringtoformat = value;}};//syntax is wrong
                   private string _formattedString;
                   public string FormattedString {get return _formattedString;}
                   public Layout(string formattype, int siteid)
                   {
                        //get format type logic here
                        //if(formattype.ToLower() =="html")
                        //{ . . . do something . . . }
    
                        //call XML Doc for specific site, based upon formattype
       
                      if(!String.IsNullorEmpty(_stringtoformat))                   
                          {
                          //you will want to put another loop here to loop over all of the custom styles
                             foreach(node n in siteNode)
                              {
                               _stringtoformat.Replace(n.value, n.text); 
                              }
                          }
                          //Sorry, can't write XML document parsing code off the top of my head
                         _formattedString = _stringtoformat;
                    }          
                   public string bold(this string x) {
                       return start_bold + x + end_bold;
                   }
                   public string italics(this string x) {
                       return start_italics + x+ end_italics;
                   }
                                   
                }
   
