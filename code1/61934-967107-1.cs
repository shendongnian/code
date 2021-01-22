    System.Text.StringBuilder sb = new System.Text.StringBuilder();
    System.IO.StringReader sr = new System.IO.StringReader(originalString);
    string tmpS = null;
    do {
        tmpS = sr.ReadLine();
        if (tmpS != null) {
            sb.Append(tmpS);
            sb.Append("<br />");
        }
    } while (tmpS != null);
    var convertedString = sb.ToString();
