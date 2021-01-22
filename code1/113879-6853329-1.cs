    using System;
    using System.Collections.Generic;
    using System.Linq;
    using System.Text;
    namespace GadgetActivator
    {
        class Program
        {
            static void Main(string[] args)
            {
                Type t = Type.GetTypeFromCLSID(new Guid("924ccc1b-6562-4c85-8657-d177925222b6"));
                IDesktopGadget dg = (IDesktopGadget)Activator.CreateInstance(t);
                dg.RunGadget(@"C:\Program Files\Windows Sidebar\Gadgets\xxxxxxxxx.Gadget");
            }
       }
    }
