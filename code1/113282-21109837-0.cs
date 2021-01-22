    //usings
    using System;
    using System.Messaging;
    using System.Runtime.InteropServices;
    using System.Security;
    using System.Security.Principal;
    //Declaring the advapi32.dll
     [DllImport("advapi32.dll", SetLastError = true)]
        public static extern bool LogonUser(
                string lpszUsername,
                string lpszDomain,
                string lpszPassword,
                int dwLogonType,
                int dwLogonProvider,
                out IntPtr phToken);
    private void IterateRemoteMQ()
        {
            IntPtr userToken = IntPtr.Zero;
            bool success = LogonUser(
              "REMOTE_USERNAME", //Username on the remote machine
              ".",  //Domain, if not using AD, Leave it at "."
              "PASSWORD",  //Password for the username on the remote machine
              9, //Means we're using new credentials, otherwise it will try to impersonate a local user
              0,
              out userToken);
            if (!success)
            {
                throw new SecurityException("Logon user failed");
            }
            //Go through each queue to see if yours exists, or do some operation on that queue.
            using (WindowsIdentity.Impersonate(userToken))
            {
                MessageQueue[] Queues = MessageQueue.GetPrivateQueuesByMachine("192.168.1.10");
                foreach (MessageQueue mq in Queues)
                {
                    string MSMQ_Name = mq.QueueName;
                }
            }
