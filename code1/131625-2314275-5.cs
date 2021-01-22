    public class ClientApplication
    {
        void main()
        {
           ClassLibrary myCL = new ClassLibrary();
           myCL.myOtherCl.DeviceAttached += new EventHandler(myCl_deviceAttached);
        }
    
        void myCl_deviceAttached(object sender, EventArgs e)
        {
             //do stuff...
        }
    }
