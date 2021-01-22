    namespace Majiic.Ninject
    {
    static public class WinFormsInstanceProviderAux
    {
        static public void InjectDescendantOf(this IKernel kernel, ContainerControl containerControl)
        {
            var childrenControls = containerControl.Controls.Cast<Control>();
            foreach (var control in childrenControls )
            {
                InjectUserControlsOf(kernel, control);
            }
        }
        
        static private void InjectUserControlsOf(this IKernel kernel, Control control)
        {
            //only user controls can have properties defined as n-inject-able
            if (control is UserControl)
            {
                Trace.TraceInformation("Injecting dependencies in User Control of type {0}", control.GetType());
                kernel.Inject(control);
            }
            //A non user control can have children that are user controls and should be n-injected
            var childrenControls = control.Controls.Cast<Control>();
            foreach (var childControl in childrenControls )
            {
                InjectUserControlsOf(kernel, childControl );
            }
        }
    }
    }
