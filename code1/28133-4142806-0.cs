    using System;
    using System.Collections.Generic;
    using System.Net.NetworkInformation;
    using PacketDotNet;
    using SharpPcap;
    namespace SharpPcap.Test.Example9
    {
        public class DumpTCP
        {
            public static void Main(string[] args)
            {
                // Print SharpPcap version
                string ver = SharpPcap.Version.VersionString;
                Console.WriteLine("SharpPcap {0}, Example9.SendPacket.cs\n", ver);
                // Retrieve the device list
                var devices = CaptureDeviceList.Instance;
                // If no devices were found print an error
                if(devices.Count < 1)
                {
                    Console.WriteLine("No devices were found on this machine");
                    return;
                }
                Console.WriteLine("The following devices are available on this machine:");
                Console.WriteLine("----------------------------------------------------");
                Console.WriteLine();
                int i = 0;
                // Print out the available devices
                foreach(var dev in devices)
                {
                    Console.WriteLine("{0}) {1}",i,dev.Description);
                    i++;
                }
                Console.WriteLine();
                Console.Write("-- Please choose a device to send a packet on: ");
                i = int.Parse( Console.ReadLine() );
                var device = devices[i];
                Console.Write("What MAC address are you sending the WOL packet to: ");
                string response = Console.ReadLine().ToLower().Replace(":", "-");
                //Open the device
                device.Open();
                EthernetPacket ethernet = new EthernetPacket(PhysicalAddress.Parse(
                    "ff-ff-ff-ff-ff-ff"), PhysicalAddress.Parse("ff-ff-ff-ff-ff-ff"),
                    EthernetPacketType.WakeOnLan);
                ethernet.PayloadPacket = new WakeOnLanPacket(
                    PhysicalAddress.Parse(response));
                byte[] bytes = ethernet.BytesHighPerformance.Bytes;
                try
                {
                    //Send the packet out the network device
                    device.SendPacket(bytes);
                    Console.WriteLine("-- Packet sent successfuly.");
                }
                catch(Exception e)
                {
                    Console.WriteLine("-- "+ e.Message );
                }
                //Close the pcap device
                device.Close();
                Console.WriteLine("-- Device closed.");
                Console.Write("Hit 'Enter' to exit...");
                Console.ReadLine();
            }
        }
    }
