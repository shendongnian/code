    using System.Runtime.InteropServices;
    using Microsoft.WindowsMediaServices.Interop;
    
    // instantiating the server for a remote host
    Type serverType = Type.GetTypeFromProgID("WMSServer.Server", "MediaServer");
    
    // may need to wrap this in an impersonation context depending the server's ACL
    WMSServer server = (WMSServer)Activator.CreateInstance(serverType); 
    
    // removing all of the publish points
    for(int i = server.PublishingPoints.Count - 1; i >= 0; i--)
    {
       server.PublishingPoints.Remove(i);
    }
    
    // adding a push broadcast point
    IWMSBroadcastPublishingPoint newPoint = 
              (IWMSBroadcastPublishingPoint) server.PublishingPoints.Add(
                 "NewPoint", WMS_PUBLISHING_POINT_CATEGORY.WMS_PUBLISHING_POINT_BROADCAST,
                  "Push:*");
    
    // cloning
    IWMSPublishingPoint cloned = server.PublishingPoints.Clone("Cloned", newPoint);
