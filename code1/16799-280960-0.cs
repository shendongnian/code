    String appToHookTo = "applicationthatloadedthedll";
    Process[] foundProcesses = Process.GetProcessesByName(appToHookTo)
    ProcessModuleCollection modules = foundProcesses[0].Modules;
    ProcessModule dllBaseAdressIWant = null;
    foreach (ProcessModule i in modules) {
    if (i.ModuleName == "nameofdlliwantbaseadressof") {
                        dllBaseAdressIWant = i;
                    }
            }
