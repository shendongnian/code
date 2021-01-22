    static string sMessages(Expression<Func<List<string>>> aMessages) {
        var messages = aMessages.Compile()();
        if (messages.Count == 0) {
            return "";
        }
        StringBuilder ret = new StringBuilder();
        string sType = ((MemberExpression)aMessages.Body).Member.Name;
        ret.AppendFormat("<p class=\"{0}\">", sType);
        foreach (string msg in messages) {
            ret.Append(msg);
            ret.Append("<br />");
        }
        ret.Append("</p>");
        return ret.ToString();
    }
