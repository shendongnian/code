	string look_for = "bbb";
	ArrayList names = new ArrayList();
	names.Add("aaa");
	names.Add("bbb");
	names.Add("ccc");
	
	foreach (string name in names)
	{
	if (look_for == name)
	{
	break;
	}
	}
