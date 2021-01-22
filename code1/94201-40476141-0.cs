    private string DateCompiled()
    {
        System.Version v = System.Reflection.Assembly.GetExecutingAssembly().GetName().Version;
        // v.Build == days and v.Revision*2 == seconds since Jan. 1, 2000 at 00:00 (midnight, 12:00am). (Local time, but disregards daylight saving time.)
        return new DateTime(2000, 1, 1).AddDays(v.Build).AddSeconds(v.Revision * 2).ToString("yyyyMMdd-HHmm (local no DST)");
        // "Assembly version" has four UInt16 fields: "Major Version", "Minor Version", "Build Number", and "Revision".
        // When Build is "*" and Revision is empty, the compiler overrides them with the encoded date and time.
        // AssemblyVersion can be specified in the solution Properties window, Application tab, "Assembly Information..." button and dialog box: Assembly version.
        // AssemblyVersion can also be specified in "AssemblyInfo.cs". Example:
        //   [assembly: AssemblyVersion("2016.11.*")]
        // AssemblyFileVersion is optional, defaulting to AssemblyVersion if not specified. (Build is NOT allowed to be "*".)
        // Properties of the file (in Windows Explorer) displays AssemblyFileVersion.
        // AssemblyVersion can be specified in the solution Properties window, Application tab, "Assembly Information..." button and dialog box: File version.
        // AssemblyVersion can also be specified in "AssemblyInfo.cs". Example:
        //   [assembly: AssemblyFileVersion("1.2.3.4")]
    }
