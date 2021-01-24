    var subscriptiondId = "subscription Id";
    var credentials =  SdkContext.AzureCredentialsFactory.FromFile(@"path of creditial file");
    var resouceGroup = "resouce group";
    var hostName = "host name";
    NetworkManagementClient networkManagement = new NetworkManagementClient(credentials) { SubscriptionId = subscriptiondId };
    ComputeManagementClient computeManagement =
    new ComputeManagementClient(credentials) {SubscriptionId = subscriptiondId};
    var nic = computeManagement.VirtualMachines.GetAsync(resouceGroup, hostName).Result.NetworkProfile.NetworkInterfaces
                .FirstOrDefault();
    var networkIntefaceName = nic?.Id.Split('/').Last();
    var ipConfiguration  = networkManagement.NetworkInterfaces.GetAsync(resouceGroup, networkIntefaceName).Result.IpConfigurations.FirstOrDefault();
    var publicIpAddressId = ipConfiguration?.PublicIPAddress.Id;
    var ip = networkManagement.PublicIPAddresses.GetAsync(resouceGroup, publicIpAddressId?.Split('/').Last()
