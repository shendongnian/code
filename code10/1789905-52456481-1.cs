    IL_0000: ldarg.1
    IL_0001: ldstr "\\[(.*?)\\]"
    IL_0006: call class [System]System.Text.RegularExpressions.Match [System]System.Text.RegularExpressions.Regex::Match(string, string)
    IL_000b: callvirt instance class [System]System.Text.RegularExpressions.GroupCollection [System]System.Text.RegularExpressions.Match::get_Groups()
    IL_0010: ldc.i4.1
    IL_0011: callvirt instance class [System]System.Text.RegularExpressions.Group [System]System.Text.RegularExpressions.GroupCollection::get_Item(int32)
    IL_0016: callvirt instance string [System]System.Text.RegularExpressions.Capture::get_Value()
    IL_001b: pop
    IL_001c: ret
