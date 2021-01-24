    using System;
    using System.Collections.Generic;
    using System.Linq;
    using System.Management;
    using System.Text.RegularExpressions;
    
    namespace PortNames
    {
        class Program
        {
            private const string vidPattern = @"VID_([0-9A-F]{4})";
            private const string pidPattern = @"PID_([0-9A-F]{4})";
    
            struct ComPort // custom struct with our desired values
            {
                public string name;
                public string vid;
                public string pid;
                public string description;
            }
    
            private static List<ComPort> GetSerialPorts()
            {
                using (var searcher = new ManagementObjectSearcher
                    ("SELECT * FROM WIN32_SerialPort"))
                {
                    var ports = searcher.Get().Cast<ManagementBaseObject>().ToList();
                    return ports.Select(p =>
                    {
                        ComPort c = new ComPort();
                        c.name = p.GetPropertyValue("DeviceID").ToString();
                        c.vid = p.GetPropertyValue("PNPDeviceID").ToString();
                        c.description = p.GetPropertyValue("Caption").ToString();
    
                        Match mVID = Regex.Match(c.vid, vidPattern, RegexOptions.IgnoreCase);
                        Match mPID = Regex.Match(c.vid, pidPattern, RegexOptions.IgnoreCase);
    
                        if (mVID.Success)
                            c.vid = mVID.Groups[1].Value;
                        if (mPID.Success)
                            c.pid = mPID.Groups[1].Value;
    
                        return c;
    
                    }).ToList();
                }
            }
            static void Main(string[] args)
            {
                List<ComPort> ports = GetSerialPorts();
                //if we want to find one device
                ComPort com = ports.FindLast(c => c.vid.Equals("0483") && c.pid.Equals("5740"));
                //or if we want to extract all devices with specified values:
                List<ComPort> coms = ports.FindAll(c => c.vid.Equals("0483") && c.pid.Equals("5740"));
    
                Console.ReadLine();
            }
        }
    }
