    System.Diagnostics.StackTrace st = new System.Diagnostics.StackTrace();
    var frames = st.GetFrames();
    System.Diagnostics.StackFrame expfm = null;
    for (int i = 0; i < frames.Length; i++)
    {
        string fn = frames[i].GetMethod().Name;
        if (fn == "get_Item" || fn == "UpdateAndExecute1") // to find the caller
        {
            expfm = frames[i + 1];
            break;
        }
        else if (fn == "Execute")
        {
            expfm = frames[i];
            break;
        }
    }
    if (expfm != null)
    {
        var mb = expfm.GetMethod().GetMethodBody();
        byte[] il = mb.GetILAsByteArray();
        int offset = expfm.GetILOffset();
        bool found = false;
        for (int i = offset; i < il.Length && i <= offset + 100; i++)
        {
            if (il[i] == OpCodes.Brtrue_S.Value && il[i + 2] == OpCodes.Pop.Value && il[i + 3] == OpCodes.Ldstr.Value)
            {
                offset = i + 4;
                found = true;
                break;
            }
        }
        if (found)
        {
            int mt = ReadInt32(il, ref offset);
            var defs = expfm.GetMethod().Module.ResolveString(mt);
        }
    }
        private static int ReadInt32(byte[] il, ref int position)
        {
            return (((il[position++] | (il[position++] << 8)) | (il[position++] << 0x10)) | (il[position++] << 0x18));
        }
