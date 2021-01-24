    bool byeFlag = false;
    var p = from line in File.ReadLines(file)
            .SkipWhile(l => l.TrimStart() != ("#define HELLO"))
            .TakeUntil(l =>
            {
                bool ret = byeFlag;
                if (l.TrimStart() == "#define BYE")
                {
                    byeFlag = true;
                }
                return ret;
            })
            .ToList()
            select new
            {
                File = file,
                Line = line
            };
