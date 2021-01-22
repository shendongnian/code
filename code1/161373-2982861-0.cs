    public partial class RemoteClientInfo : System.Web.UI.Page
    {	
    
    	public class NetUtils
            {
                //http://msdn.microsoft.com/en-us/library/aa366358(VS.85).aspx
                [System.Runtime.InteropServices.DllImport("iphlpapi.dll", ExactSpelling = true)]
                public static extern int SendARP(int DestIP, int SrcIP, byte[] pMacAddr, ref uint PhyAddrLen);
    
                private static System.Net.IPAddress GetIpAddress(string address)
                {
                    System.Net.IPHostEntry hostEntry = System.Net.Dns.GetHostEntry(address);
                    if (hostEntry != null)
                    {
                        foreach (System.Net.IPAddress ipAddress in hostEntry.AddressList)
                        {
                            if (ipAddress.AddressFamily == System.Net.Sockets.AddressFamily.InterNetwork)
                            {
                                return ipAddress;
                            }
                        }
                    }
                    return null;
                }
    
                public static string GetMacAddress(string address)
                {
                    System.Net.IPAddress ipAddress = GetIpAddress(address);
    
                    if (ipAddress != null)
                    {
                        byte[] addressBytes = ipAddress.GetAddressBytes();
                        byte[] macAddress = new byte[6];
                        uint macAddressLen = (uint)macAddress.Length;
                        if (SendARP(BitConverter.ToInt32(addressBytes, 0), 0, macAddress, ref macAddressLen) == 0)
                        {
                            return BitConverter.ToString(macAddress);
                        }
                    }
                    return null;
                }
            }
    
            protected void GetClientInfoButton_Click(object sender, EventArgs e)
            {
                string remoteIp = System.Web.HttpContext.Current.Request.UserHostAddress;
                string remoteMacAddr = NetUtils.GetMacAddress(remoteIp);
                this.InfoTextBox.Text = string.Format("ip=[{0}] mac=[{1}]", remoteIp, remoteMacAddr);
            }
    }
