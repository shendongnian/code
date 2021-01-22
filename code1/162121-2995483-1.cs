    Dictionary<string, string> d = new Dictionary<string, string>();
    string s1 = "user=u123;name=Test;lastname=User";
    foreach (string s2 in s1.Split(';')) 
    {
    	string[] split = s2.Split('=');
    	d.Add(split[0], split[1]);
    }
