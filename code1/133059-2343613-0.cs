    public override string ToString()
    {
         stringBuilder sb = ... your usual string output
         AppendDebug(sb);
         return sb.Tostring();
    }
    [Conditional("DEBUG")]
    private void AppendDebug(stringBuilder sb)
    {
       sb.Append( ... debug - specific info )
    }
