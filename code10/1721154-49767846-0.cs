    using System.Management;
    string folderID = ((ManagementBaseObject)TS["SMS_ObjectContainerItem"].ObjectValue)["ContainerNodeID"].ToString();
    
    // or
    
    ManagementBaseObject tsp = TS["SMS_TaskSequencePackage"].ObjectValue as ManagementBaseObject;
    string packageID = tsp["PackageID"].ToString();
