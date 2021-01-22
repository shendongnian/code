    using System;
    using System.Collections.Generic;
    using System.Text;
    
    using SnmpSharpNet;
    
    namespace Exemple2
    {
      class Program
      {
        static void Main(string[] args)
        {
          /* Get an SNMP Object
           */
          SimpleSnmp snmpVerb = new SimpleSnmp("192.168.1.121", 161, "public");
          if (!snmpVerb.Valid)
          {
            Console.WriteLine("Seems that IP or comunauty is not cool");
            return;
          }
    
    
          /* Sample of simple Get usage on ifSpeed on interface 10
           * TODO : for sure you have to detect the right interface
           */
          Oid oidifSpeed = new Oid(".1.3.6.1.2.1.2.2.1.5.10");
    
          /* Getting ifSpeed
           */
          Dictionary<Oid, AsnType> snmpDataS = snmpVerb.Get(SnmpVersion.Ver2, new string[] { oidifSpeed.ToString() });
          if (snmpDataS != null)
            Console.WriteLine("Interface speed \"{0}\" : {1}", oidifSpeed.ToString(), snmpDataS[oidifSpeed].ToString());
          else
            Console.WriteLine("Not Glop!");
    
          /* Sample of simple Get usage on ifInOctets on interface 10
           * TODO : for sure you have to detect the right interface
           */
          Oid oidifInOctets = new Oid(".1.3.6.1.2.1.2.2.1.10.10");
          Dictionary<Oid, AsnType> snmpData1;
    
          /* Getting it for the first time
           */
          snmpData1 = snmpVerb.Get(SnmpVersion.Ver2, new string[] { oidifInOctets.ToString() });
          if (snmpData1 != null)
            Console.WriteLine("Number of In octets \"{0}\" : {1}", oidifInOctets.ToString(), snmpData1[oidifInOctets].ToString());
          else
            Console.WriteLine("Not Glop!");
    
          int missed = 0;
          while (true)
          {
            if (missed == 0)
            {
              /* When you detect a non refesh data, keep the last one
               */
              snmpData1 = snmpVerb.Get(SnmpVersion.Ver2, new string[] { oidifInOctets.ToString() });
              if (snmpData1 != null)
                Console.WriteLine("Number of In octets \"{0}\" : {1}", oidifInOctets.ToString(), snmpData1[oidifInOctets].ToString());
              else
                Console.WriteLine("Not Glop!");
            }
    
            /* Some Wait (less aproximative)
             */
            int duration = 5;
            System.Threading.Thread.Sleep(duration*1000); // duration seconds
    
            /* Getting it for the Second time
             */
            Dictionary<Oid, AsnType> snmpData2 = snmpVerb.Get(SnmpVersion.Ver2, new string[] { oidifInOctets.ToString() });
            if (snmpData2 != null)
              Console.WriteLine("Number of In octets \"{0}\" : {1}", oidifInOctets.ToString(), snmpData2[oidifInOctets].ToString());
            else
              Console.WriteLine("Not Glop!");
    
            Counter32 I1 = new Counter32();
            I1.Set(snmpData1[oidifInOctets]);
            Counter32 I2 = new Counter32();
            I2.Set(snmpData2[oidifInOctets]);
            Counter32 speed = new Counter32();
            speed.Set(snmpDataS[oidifSpeed]);
    
            if (I2.Value == I1.Value)
            {
              missed += 1;
              continue;
            }
            decimal bandWithUsage = (((decimal)(I2.Value - I1.Value) * 8) * 100) / (speed * duration * (1+missed));
            Console.WriteLine("BandWith usage : {0}%", bandWithUsage);
            missed = 0;
          }
        }
      }
    }
