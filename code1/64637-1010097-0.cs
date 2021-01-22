    string s = "";
    List<string> a = new List<string>();
    
    for (int i = 0; i <= 7000; i++) {
        s += "a";
    }
    
    for (int i = 0; i <= s.Length; i += 76) {
        
        if ((i + 76) > s.Length) {
            a.Add(s.Substring(i) + "\r\n");
        }
        else {
            a.Add(s.Substring(i, 76) + "\r\n");
            
        }
    }
