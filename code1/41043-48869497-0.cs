    var password = "qwertyuiop123";
    var startTime = DateTime.Now;
    "From DB:".Dump();
    startTime = DateTime.Now;
    if (CommonPasswords.Any(c => System.Data.Linq.SqlClient.SqlMethods.Like(c.Word, password)))
    {
        $"FOUND: processing time: {(DateTime.Now - startTime).TotalMilliseconds}\r\n".Dump();
    }
    else
    {
        $"NOT FOUND: processing time: {(DateTime.Now - startTime).TotalMilliseconds}\r\n".Dump();
    }
    "From DB:".Dump();
    startTime = DateTime.Now;
    if (CommonPasswords.Where(c => System.Data.Linq.SqlClient.SqlMethods.Like(c.Word, password)).Count() > 0)
    {
        $"FOUND: processing time: {(DateTime.Now - startTime).TotalMilliseconds}\r\n".Dump();
    }
    else
    {
        $"NOT FOUND: processing time: {(DateTime.Now - startTime).TotalMilliseconds}\r\n".Dump();
    }
    "From DB:".Dump();
    startTime = DateTime.Now;
    if (CommonPasswords.Where(c => c.Word.ToLower() == password).Take(1).Any())
    {
        $"FOUND: processing time: {(DateTime.Now - startTime).TotalMilliseconds}\r\n".Dump();
    }
    else
    {
        $"NOT FOUND: processing time: {(DateTime.Now - startTime).TotalMilliseconds}\r\n".Dump();
    }
