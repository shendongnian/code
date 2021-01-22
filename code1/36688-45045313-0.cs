    using Microsoft.VisualBasic.Devices;
    var versionID = new ComputerInfo().OSVersion;//6.1.7601.65536
    var versionName = new ComputerInfo().OSFullName;//Microsoft Windows 7 Ultimate
    var verionPlatform = new ComputerInfo().OSPlatform;//WinNT
    Console.WriteLine(versionID);
    Console.WriteLine(versionName);
    Console.WriteLine(verionPlatform);
