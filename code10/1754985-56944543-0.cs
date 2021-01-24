c#
using System;
using System.Diagnostics;
static class IsRanFromConsole
{
    private static readonly string[] consoleNames = {
        "cmd", "bash", "ash", "dash", "ksh", "zsh", "csh",
        "tcsh", "ch", "eshell", "fish", "psh", "pwsh", "rc",
        "sash", "scsh", "powershell", "tcc"
    };
    private static bool isCache = false;
    private static bool isConsole;
    public static bool IsConsole()
    {
        if (!isCache)
        {
            string parentProc = Process.GetCurrentProcess().Parent().ProcessName;
            isConsole = Array.IndexOf(consoleNames, parentProc) > -1;
        }
        return isConsole;
    }
}
Usage:
c#
Console.WriteLine(IsRanFromConsole.IsConsole());
For the `.Parent()` function, you need to add [this code](https://stackoverflow.com/a/2336322/11585798).
