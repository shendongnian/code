    string s = "THIS IS MY TEXT RIGHT NOW";
    s = System.Globalization.CultureInfo.CurrentCulture.TextInfo.ToTitleCase(s.ToLower());
    IL_0000:  ldstr       "THIS IS MY TEXT RIGHT NOW"
    IL_0005:  stloc.0     // s
    IL_0006:  call        System.Globalization.CultureInfo.get_CurrentCulture
    IL_000B:  callvirt    System.Globalization.CultureInfo.get_TextInfo
    IL_0010:  ldloc.0     // s
    IL_0011:  callvirt    System.String.ToLower
    IL_0016:  callvirt    System.Globalization.TextInfo.ToTitleCase
    IL_001B:  stloc.0     // s
