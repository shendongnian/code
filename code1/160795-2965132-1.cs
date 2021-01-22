    using System.Text.RegularExpressions;
    // ...
    for(int i=0; i<argv.Length; i++) {
        if (Regex.IsMatch(i, "(\s|\")+")) {
            argv[i] = "\"" + argv[i] + "\"";
            argv[i].Replace("\"", "\\\"");
        }
    }
