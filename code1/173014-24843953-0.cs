    using System;
    using System.Collections.Generic;
    using System.Diagnostics;
    using System.Linq;
    using System.Text;
    using System.Threading.Tasks;
    using NATUPNPLib; // Add this dll from referance and chande Embed Interop Interop to false from properties panel on visual studio
    using System.Net;
    namespace Client
    {
        class NATTRAVERSAL
        {
            //This is code for get external ip
            private void NAT_TRAVERSAL_ACT()
            {
                UPnPNATClass uPnP = new UPnPNATClass();
                IStaticPortMappingCollection map = uPnP.StaticPortMappingCollection;
    
                foreach (IStaticPortMapping item in map)
                {
                        Debug.Print(item.ExternalIPAddress); //This line will give you external ip as string
                        break;
                }
            }
        }
    }
