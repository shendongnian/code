private static string VersionName(int versionNum)
{
    StringBuilder sb = new StringBuilder();
    while (versionNum > 0)
    {
        versionNum--;
        sb.Insert(0, (char)('A' + (versionNum % 26)));
        versionNum /= 26;
    }
    return sb.ToString();
}
