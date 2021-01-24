     private void test()
    {
    list<string> html = new list<string>(File.ReadAllLines("htmlFIlePathHere"));
    list<string> myFile = new list<string>(File.ReadAllLines("filepathhere"));
    int index;
    string foundWord = "";
    foreach (var ite in htmk)
    {
        if (ite.Contains("<lc:default"))
        {
            index = html.FindIndex(a => a == ite);
            foundWord = ite;
        }
    }
    html(index).Replace(foundWord, "");
    foreach (var item in myFile)
    {
        html(index) = item;
        index = index + 1;
    }
    html.Add("<body>")
    html.Add("</body>")
    foreach (var item in html)
    {
        MsgBox(item); /// u have a list of strings or should i say u have your  result, use it the way you want :)
    }
    }
   
     
