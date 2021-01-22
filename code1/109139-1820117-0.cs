    //Namespace reference
    using System.Management;
    
    /// <summary>
    /// Returns MAC Address from first Network Card in Computer
    /// </summary>
    /// <returns>MAC Address in string format</returns>
    public string FindMACAddress()
    {
        //create out management class object using the
        //Win32_NetworkAdapterConfiguration class to get the attributes
        //af the network adapter
        ManagementClass mgmt = new ManagementClass("Win32_NetworkAdapterConfiguration");
        //create our ManagementObjectCollection to get the attributes with
        ManagementObjectCollection objCol = mgmt.GetInstances();
        string address = String.Empty;
        //My modification to the code
        var description = String.Empty;
        //loop through all the objects we find
        foreach (ManagementObject obj in objCol)
        {
            if (address == String.Empty)  // only return MAC Address from first card
            {
                //grab the value from the first network adapter we find
                //you can change the string to an array and get all
                //network adapters found as well
                if ((bool)obj["IPEnabled"] == true)
                {
                    address = obj["MacAddress"].ToString();
                    description = obj["Description"].ToString();
                }
            }
           //dispose of our object
           obj.Dispose();
        }
        //replace the ":" with an empty space, this could also
        //be removed if you wish
        address = address.Replace(":", "");
        //return the mac address
        return address;
    }
