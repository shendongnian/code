    string myList = Request.Form["myList"];
    if(string.isNullOrEmpty(myList))
    {
        Response.Write("Nothing selected.");
        return;
    }
    foreach (string Item in myList.split(new char[] {','}, StringSplitOptions.RemoveEmptyEntries))
    {
      Response.Write(item + "<hr>");
    }
