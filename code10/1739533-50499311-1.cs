    static string regRep(string inp)
    {
        return inp.Replace("*", ".*").Replace('?', '.').Replace("-", @"\-");
    }
    
    static string regRep2(string inp)
    {
        return inp.Replace("*", ".*").Replace('?', '.').Replace("-", ".");
    }
    static void Main()
    {
        var patterns = new string[] { "8888*", "8889*", "8898*", "8899*", "8988*", "8989*", "8989*", "8999*", "7898*", "7899*", "8888?8", "888?-8", "*88*" };
        string ar = @"888?-*";
        
        List<string> res = new List<string>();
        
        bool mat1, mat2;
        Regex reg1, reg2;
        foreach (var reg in patterns)
        {
            reg1 = new Regex(regRep(reg));
            reg2 = new Regex(regRep(ar));
        
            mat1 = reg1.IsMatch(ar);
            mat2 = reg2.IsMatch(reg);
            
            // standard matching
            if (mat1 || mat2)
            {
                res.Add($"{ar} std matched with {reg}");
            }
            else
            {
                //forced matching
                reg1 = new Regex(regRep2(reg));
                reg2 = new Regex(regRep2(ar));
                mat1 = reg1.IsMatch(ar);
                mat2 = reg2.IsMatch(reg);
        
                if (mat1 || mat2)
                {
                    res.Add($"{ar} frc matched with {reg}");
                }
            }
        }
    }
    //result
    Count = 5
        [0]: "888?-* frc matched with 8888*"
        [1]: "888?-* frc matched with 8889*"
        [2]: "888?-* frc matched with 8888?8"
        [3]: "888?-* std matched with 888?-8"
        [4]: "888?-* std matched with *88*"
