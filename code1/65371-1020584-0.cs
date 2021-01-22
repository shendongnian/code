using System;
using Microsoft.Win32;
  class Class1
  {
    static void Main(string[] args)
    {
      RegistryKey RegKey = Registry.LocalMachine;
      RegKey = RegKey.OpenSubKey("HARDWARE\\DESCRIPTION\\System\\CentralProcessor\\0");
      Object cpuSpeed = RegKey.GetValue("~MHz");
      Object cpuType  = RegKey.GetValue("VendorIdentifier");
      Console.WriteLine("You have a {0} running at {1} MHz.",cpuType,cpuSpeed);
    }
  }
