    string s = "Managers Alice, Bob, Charlie\r\nSupervisors Don, Edward, Francis";
    var result =
        from line in s.Split(new string[] { "\r\n" }, StringSplitOptions.None)
        let parts = line.Split(new char[] { ' ' }, 2)
        let title = parts[0]
        let names = parts[1]
        from name in names.Split(new char[] { ',' })
        select title.Trim() + " " + name.Trim();
