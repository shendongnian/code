    using System;
    using Extensibility;
    using EnvDTE;
    using EnvDTE80;
    using Microsoft.VisualStudio.CommandBars;
    using System.Resources;
    using System.Reflection;
    using System.Globalization;
    using Microsoft.VisualStudio.Shell.Interop;
    using Microsoft.VisualStudio.Shell;
    using Microsoft.VisualStudio.OLE.Interop;
    using System.Collections.Generic;
    public class HelpAttribute
    {
        public string Name;
        public string Value;
        public VSUSERCONTEXTPRIORITY Priority;
        public VSUSERCONTEXTATTRIBUTEUSAGE Usage;
    }
    public class HelpContext2 : List<HelpAttribute>
    {
        public static HelpContext2 GetHelpContext(DTE2 dte)
        {
            // Get a reference to the current active window (presumably a code editor).
            Window activeWindow = dte.ActiveWindow;
            // make a few gnarly COM-interop calls in order to get Help Context 
            Microsoft.VisualStudio.OLE.Interop.IServiceProvider sp = (Microsoft.VisualStudio.OLE.Interop.IServiceProvider)activeWindow.DTE;
            Microsoft.VisualStudio.Shell.ServiceProvider serviceProvider = new Microsoft.VisualStudio.Shell.ServiceProvider(sp);
            IVsMonitorUserContext contextMonitor = (IVsMonitorUserContext)serviceProvider.GetService(typeof(IVsMonitorUserContext));
            IVsUserContext userContext;
            int hresult = contextMonitor.get_ApplicationContext(out userContext);
            HelpContext2 attrs = new HelpContext2(userContext);
            return attrs;
        }
        public HelpContext2(IVsUserContext userContext)
        {
            int count;
            userContext.CountAttributes(null, 1, out count);
            for (int i = 0; i < count; i++)
            {
                string name, value;
                int priority;
                userContext.GetAttributePri(i, null, 1, out priority, out name, out value);
                VSUSERCONTEXTATTRIBUTEUSAGE[] usageArray = new VSUSERCONTEXTATTRIBUTEUSAGE[1];
                userContext.GetAttrUsage(i, 1, usageArray);
                VSUSERCONTEXTATTRIBUTEUSAGE usage = usageArray[0];
                HelpAttribute attr = new HelpAttribute();
                attr.Name = name;
                attr.Value = value;
                attr.Priority = (VSUSERCONTEXTPRIORITY)priority;
                attr.Usage = usage; // name == "keyword" ? VSUSERCONTEXTATTRIBUTEUSAGE.VSUC_Usage_Lookup : VSUSERCONTEXTATTRIBUTEUSAGE.VSUC_Usage_Filter;
                this.Add(attr);
            }
        }
        public string CaseSensitiveKeyword
        {
            get
            {
                HelpAttribute caseSensitive = Keywords.Find(attr => 
                    attr.Usage == VSUSERCONTEXTATTRIBUTEUSAGE.VSUC_Usage_LookupF1_CaseSensitive
                    || attr.Usage == VSUSERCONTEXTATTRIBUTEUSAGE.VSUC_Usage_Lookup_CaseSensitive
                    );
                return caseSensitive == null ? null : caseSensitive.Value;
            }
        }
        public List<HelpAttribute> Keywords
        {
            get
            {
                return this.FindAll(attr=> attr.Name == "keyword");
            }
        }
    }
