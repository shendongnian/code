    public static SqlString RegexSubstring(SqlString regexpattern,
                                   SqlString sourcetext,
                                   SqlInt32 start_position) {
        if (regexpattern.IsNull || sourcetext.IsNull || start_position.IsNull)
            return null;
        Regex RegexInstance = new Regex(regexpattern.ToString());
        
        return new SqlString(RegexInstance.Match(sourcetext.ToString(),
                                                   (int)start_position).Value);
    }
