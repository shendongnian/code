    using System;
    using System.Collections.Generic;
    using System.ComponentModel;
    using System.ComponentModel.Design;
    using System.Reflection;
    using System.Windows.Forms;
 
    namespace ReferencedAssemblies
    {
        public partial class GetReferencedComponents : Component, ISupportInitialize
        {
            private Control hostingControl;
            public GetReferencedComponents(IContainer container) : this()
            {
                container.Add(this);
            }
            public GetReferencedComponents()
            {
                InitializeComponent();
                Assemblies = new List<string>();
                GetAssemblies();
            }
            public List<string> Assemblies { get; private set;  }
 
            [Browsable(false)]
            public Control HostingControl
            {
                get
                {
                    if (hostingControl == null && this.DesignMode)
                    {
                        IDesignerHost designer = this.GetService(typeof(IDesignerHost)) as IDesignerHost;
                        if (designer != null)
                            hostingControl = designer.RootComponent as Control;
                    }
                    return hostingControl;
                }
                set
                {
                    if (!this.DesignMode && hostingControl != null && hostingControl != value)
                        throw new InvalidOperationException("Cannot set at runtime.");
                    else
                        hostingControl = value;
                }
            }
            public void BeginInit()
            {
            }
            public void EndInit()
            {
                // use ISupportInitialize.EndInit() to trigger loading assemblies at design-time.
                GetAssemblies();
            }
            private void GetAssemblies()
            {
                if (HostingControl != null)
                {
                    if (this.DesignMode)
                        MessageBox.Show(String.Format("Getting Referenced Assemblies from {0}", HostingControl.Name));
                    Assemblies.Clear();
                    AssemblyName[] assemblyNames = HostingControl.GetType().Assembly.GetReferencedAssemblies();
                    foreach (AssemblyName item in assemblyNames)
                        Assemblies.Add(item.Name);
                }
            }
        }
