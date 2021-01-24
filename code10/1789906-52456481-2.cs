    .locals init (
        [0] string,
        [1] class [System]System.Text.RegularExpressions.Match,
        [2] string
    )
    IL_0000: nop
    IL_0001: ldstr "\\[(.*?)\\]"
    IL_0006: stloc.0
    IL_0007: ldarg.1
    IL_0008: ldloc.0
    IL_0009: call class [System]System.Text.RegularExpressions.Match [System]System.Text.RegularExpressions.Regex::Match(string, string)
    IL_000e: stloc.1
    IL_000f: ldloc.1
    IL_0010: callvirt instance class [System]System.Text.RegularExpressions.GroupCollection [System]System.Text.RegularExpressions.Match::get_Groups()
    IL_0015: ldc.i4.1
    IL_0016: callvirt instance class [System]System.Text.RegularExpressions.Group [System]System.Text.RegularExpressions.GroupCollection::get_Item(int32)
    IL_001b: callvirt instance string [System]System.Text.RegularExpressions.Capture::get_Value()
    IL_0020: stloc.2
    IL_0021: ret
