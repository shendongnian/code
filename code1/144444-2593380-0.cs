    var a = File.ReadAllLines("A.txt");
    var b = File.ReadAllLines("B.txt");
    
    var query =
        from bline in b
        let parts = bline.Split('|')
        group parts[1] by parts[0] into bg
        join aline in a on bg.Key equals aline
        select aline + "|" + string.Join("|", bg.ToArray());
    
    File.WriteAllLines("result.txt", query.ToArray());
