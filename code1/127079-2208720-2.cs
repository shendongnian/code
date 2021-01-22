Using System;
Using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using System.Runtime.Interop;
using System.Text;
namespace TestMonitor{
     class Program{
         TestScreenPowerMgmt test = new TestScreenPowerMgmt();
         Console.WriteLine("Press a key to continue...");
         Console.ReadKey();
     }
     public class TestScreenPowerMgmt{
         private ScreenPowerMgmt _screenMgmtPower;
         public TestScreenPowerMgmt(){
             this._screenMgmtPower = new ScreenPowerMgmt;
             this._screenMgmtPower.ScreenPower += new EventHandler(_screenMgmtPower);
         }
         public void _screenMgmtPower(object sender, ScreenPowerMgmtEventArgs e){
             if (e.PowerStatus == PowerMgmt.StandBy) Console.WriteLine("StandBy Event!");
             if (e.PowerStatus == PowerMgmt.Off) Console.WriteLine("Off Event!");
             if (e.PowerStatus == PowerMgmt.On) Console.WriteLine("On Event!");
         }
         
     }
}
