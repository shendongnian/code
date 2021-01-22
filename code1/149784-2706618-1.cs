    string s1 = "tom";
    string s2 = "tom";
            
    Console.Write(object.ReferenceEquals(s2, s1)); //true 
    string s3 = "tom";
    string s4 = "to";
    s4 += "m";
    Console.Write(object.ReferenceEquals(s3, s4)); //false
    string s5 = String.Intern(s4);
    Console.Write(object.ReferenceEquals(s3, s5)); //true
