    using System;
    using System.Linq;
    using Microsoft.Management.Infrastructure;
    using Microsoft.Management.Infrastructure.Options;
    
    namespace TestApp
    {
        class Program
        {
            public static void CreateSnapshot()
            {
                const string hvNamespace = @"root\virtualization\v2";
    
                var sessionOptions = new DComSessionOptions
                {
                    Timeout = TimeSpan.FromSeconds(30)
                };
    
                var cimSession = CimSession.Create("localhost", sessionOptions);
    
                // Get an instance of the VM to snapshot
                var vm = cimSession.QueryInstances(hvNamespace, "WQL", $"SELECT * FROM CIM_ComputerSystem WHERE ElementName = 'MyTestVM'").First();
    
                // Get the instance of Msvm_VirtualSystemSnapshotService. There is only one.
                var vmSnapshotService = cimSession.EnumerateInstances(hvNamespace, "Msvm_VirtualSystemSnapshotService").First();
    
                // Set the snapshot parameters by creating a Msvm_VirtualSystemSnapshotSettingData
                var snapshotSettings = new CimInstance("Msvm_VirtualSystemSnapshotSettingData");
                snapshotSettings.CimInstanceProperties.Add(CimProperty.Create("ConsistencyLevel", 1, CimType.UInt8, CimFlags.ReadOnly));
                snapshotSettings.CimInstanceProperties.Add(CimProperty.Create("IgnoreNonSnapshottableDisks", true, CimFlags.ReadOnly));
    
                // Put all of these things into a CimMethodParametersCollection.
                // Note; no need to specify the "Out" parameters. They will be returned by the call to InvokeMethod.
                var methodParameters = new CimMethodParametersCollection
                {
                    CimMethodParameter.Create("AffectedSystem", vm, CimType.Reference, CimFlags.In),
                    CimMethodParameter.Create("SnapshotSettings", snapshotSettings.ToString(), CimType.String, CimFlags.In),
                    CimMethodParameter.Create("SnapshotType", 2, CimType.UInt16, CimFlags.In),
                };
    
                cimSession.InvokeMethod(hvNamespace, vmSnapshotService, "CreateSnapshot", methodParameters);
    
                Console.WriteLine($"Snapshot created!");
            }
    
            static void Main(string[] args)
            {
                CreateSnapshot();
                Console.ReadLine();
            }
        }
    }
