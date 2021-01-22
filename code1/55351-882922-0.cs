    using System;
    using System.Management;
    
    public class PrintTestPageUsingWMI
    {
        private String _name;
        private ManagementObject _printer = null;
    
    	public PrintTestPageUsingWMI(String printerName)
    	{
            this._name = printerName;
    
            //Find the Win32_Printer which is a Network Printer of this name
    
            //Declare WMI Variables
            ManagementObject MgmtObject;
            ManagementObjectCollection MgmtCollection;
            ManagementObjectSearcher MgmtSearcher;
    
            //Perform the search for printers and return the listing as a collection
            MgmtSearcher = new ManagementObjectSearcher("Select * from Win32_Printer");
            MgmtCollection = MgmtSearcher.Get();
    
            foreach (ManagementObject objWMI in MgmtCollection)
            {
                if (objWMI.Item("sharename").ToString().Equals(this._name))
                {
                    this._printer = objWMI;
                }
            }
    
            if (this._printer == null)
            {
                throw new Exception("Selected Printer is not connected to this Computer");
            }        
    	}
    
        public void PrintTestPage()
        {
            this.InvokeWMIMethod("PrintTestPage");
        }
    
        /// <summary>
        /// Helper Method which Invokes WMI Methods on this Printer
        /// </summary>
        /// <param name="method">The name of the WMI Method to Invoke</param>
        /// <remarks></remarks>
        private void InvokeWMIMethod(String method) {
            if (this._printer == null)
            {
                throw new Exception("Can't Print a Test Page on a Printer which is not connected to the Computer");
            }
    
            Object[] objTemp = new Object[0] { null };
            ManagementObject objWMI;
    
            //Invoke the WMI Method
            this._printer.InvokeMethod(method, objTemp);
        }
    }
