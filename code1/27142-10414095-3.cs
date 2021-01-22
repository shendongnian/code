    using System.Management;
    ...
    var processToRun = new[] { "notepad.exe" };
    var connection = new ConnectionOptions();
    connection.Username = "username";
    connection.Password = "password";
    var wmiScope = new ManagementScope(String.Format("\\\\{0}\\root\\cimv2", REMOTE_COMPUTER_NAME), connection);
    var wmiProcess = new ManagementClass(wmiScope, new ManagementPath("Win32_Process"), new ObjectGetOptions());
    wmiProcess.InvokeMethod("Create", processToRun);
