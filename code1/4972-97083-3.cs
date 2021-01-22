    // the namespace used for publishing the WMI classes and object instances 
    [assembly: Instrumented("root/mytest")]
    using System;
    using System.Collections.Generic;
    using System.Text;
    using System.Management;
    using System.Management.Instrumentation;
    using System.Configuration.Install;
    using System.ComponentModel;
    
    namespace WMITest
    {
    
        [InstrumentationClass(System.Management.Instrumentation.InstrumentationType.Instance)] 
        //[ManagementEntity()]
        //[ManagementQualifier("Description",Value = "Obtain processor information.")]
        public class MyWMIInterface
        {
            //[System.Management.Instrumentation.ManagementBind]
            public MyWMIInterface()
            {
            }
    
            //[ManagementProbe]
            //[ManagementQualifier("Descriiption", Value="The number of processors.")]
            public int ProcessorCount
            {
                get { return Environment.ProcessorCount; }
            }
        }
    
        /// <summary>
        /// This class provides static methods to publish messages to WMI
        /// </summary>
        public static class InstrumentationProvider
        {
            /// <summary>
            /// publishes a message to the WMI repository
            /// </summary>
            /// <param name="MessageText">the message text</param>
            /// <param name="Type">the message type</param>
            public static MyWMIInterface Publish()
            {
                // create a new message
                MyWMIInterface pInterface = new MyWMIInterface();
    
                Instrumentation.Publish(pInterface);
                
                return pInterface;
            }
    
            /// <summary>
            /// revoke a previously published message from the WMI repository
            /// </summary>
            /// <param name="Message">the message to revoke</param>
            public static void Revoke(MyWMIInterface pInterface)
            {
                Instrumentation.Revoke(pInterface);
            }        
        }
    
        /// <summary>
        /// Installer class which will publish the InfoMessage to the WMI schema
        /// (the assembly attribute Instrumented defines the namespace this
        /// class gets published too
        /// </summary>
        [RunInstaller(true)]
        public class WMITestManagementInstaller :
            DefaultManagementProjectInstaller
        {
        }
    }
