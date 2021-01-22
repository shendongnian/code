    var dict = File.ReadLines("test.txt")
                   .Where(line => !string.IsNullOrWhitespace(line))
                   .Select(line => line.Split(new char[] { '=' }, 2, 0))
                   .ToDictionary(parts => parts[0], parts => parts[1]);
    
    
    or 
    
        enter code here
    
    line="to=xxx@gmail.com=yyy@yahoo.co.in";
    string[] tokens = line.Split(new char[] { '=' }, 2, 0);
    
    ans:
    tokens[0]=to
    token[1]=xxx@gmail.com=yyy@yahoo.co.in
