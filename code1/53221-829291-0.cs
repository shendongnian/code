    var sb = new System.Text.StringBuilder();
    
    sb.Append("a=" + HttpUtility.UrlEncode("TheValueOfA") + "&");
    sb.Append("b=" + HttpUtility.UrlEncode("TheValueOfB") + "&");
    sb.Append("c=" + HttpUtility.UrlEncode("TheValueOfC") + "&");
    sb.Append("d=" + HttpUtility.UrlEncode("TheValueOfD") + "&");
    
    sb.Remove(sb.Length-1, 1); // Remove the final '&'
    string result = sb.ToString();
