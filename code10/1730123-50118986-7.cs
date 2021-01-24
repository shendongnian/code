    var list = new Node("AAA");
    list = list.Add("AAAAA");
    list = list.Add("A");
    list = list.Add("AAAA");
    list = list.Add("AAAAAA");
    list = list.Add("AA");
    string max = list.Text;
    int length = max.Length;
    for(Node node = list.Head; node != null; node = node.Next)
    {
        if(node.Text.Length > length)
        {
            max = node.Text;
            length= node.Text.Length;
        }
    }
            
    // max has the longest string
