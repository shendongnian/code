    ManagementObjectSearcher searcher = 
                    new ManagementObjectSearcher("root\\Microsoft\\Windows\\Defender", 
                    "SELECT * FROM MSFT_MpThreatDetection"); 
                foreach (ManagementObject queryObj in searcher.Get())
                {
                    Console.WriteLine("-----------------------------------");
                    Console.WriteLine("MSFT_MpThreatDetection instance");
                    Console.WriteLine("-----------------------------------");
                    Console.WriteLine("ActionSuccess: {0}", queryObj["ActionSuccess"]);
                    Console.WriteLine("AdditionalActionsBitMask: {0}", queryObj["AdditionalActionsBitMask"]);
                    Console.WriteLine("AMProductVersion: {0}", queryObj["AMProductVersion"]);
                    Console.WriteLine("CleaningActionID: {0}", queryObj["CleaningActionID"]);
                    Console.WriteLine("CurrentThreatExecutionStatusID: {0}", queryObj["CurrentThreatExecutionStatusID"]);
                    Console.WriteLine("DetectionID: {0}", queryObj["DetectionID"]);
                    Console.WriteLine("DetectionSourceTypeID: {0}", queryObj["DetectionSourceTypeID"]);
                    Console.WriteLine("DomainUser: {0}", queryObj["DomainUser"]);
                    Console.WriteLine("InitialDetectionTime: {0}", queryObj["InitialDetectionTime"]);
                    Console.WriteLine("LastThreatStatusChangeTime: {0}", queryObj["LastThreatStatusChangeTime"]);
                    Console.WriteLine("ProcessName: {0}", queryObj["ProcessName"]);
                    Console.WriteLine("RemediationTime: {0}", queryObj["RemediationTime"]);
                    if(queryObj["Resources"] == null)
                        Console.WriteLine("Resources: {0}", queryObj["Resources"]);
                    else
                    {
                        String[] arrResources = (String[])(queryObj["Resources"]);
                        foreach (String arrValue in arrResources)
                        {
                            Console.WriteLine("Resources: {0}", arrValue);
                        }
                    }
                    Console.WriteLine("ThreatID: {0}", queryObj["ThreatID"]);
                    Console.WriteLine("ThreatStatusErrorCode: {0}", queryObj["ThreatStatusErrorCode"]);
                    Console.WriteLine("ThreatStatusID: {0}", queryObj["ThreatStatusID"]);
                }
