      using System;
      using System.Collections.Generic;
      using System.Text;
      using Microsoft.WindowsMobile.SharedSource.Bluetooth;
         
      namespace ToggleBluetooth
       {
         class Program
           {
              static void Main(string[] args)
             {
                  BluetoothRadio brad = new BluetoothRadio();
                  if (brad.BluetoothRadioMode == BluetoothRadioMode.Off)
                      brad.BluetoothRadioMode = BluetoothRadioMode.On;
                   else
                    brad.BluetoothRadioMode = BluetoothRadioMode.Off;
              }
         }
       }
