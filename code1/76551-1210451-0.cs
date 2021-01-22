Controller Code:
public ActionResult Index()
    {
        List&lt;string> li = new List&lt;string>();
        li.Add("test");
        ViewData["myList"] = li;
        return View();
    }
Page Code:
&lt;div>
&lt;%
   List&lt;string> li = (List&lt;string>)ViewData["myList"];
   foreach(string str in li)
   {
%>
    &lt;p>&lt;%= str %>&lt;/p>
&lt;%
}
%>
&lt;/div>
