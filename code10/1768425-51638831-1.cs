    using System;
    using IBM.WMQ;
    using System.Diagnostics;
    using System.IO;
    using System.Xml;
    using System.Linq;
    using System.Xml.Linq;
    using System.Configuration;
    
    namespace MQ_listner
    {
        internal class MQReader
        {
            private MQQueueManager qManager = null;
            private MQMessage      inQ = null;
            private bool           running = true;
    
            public MQReader()
            {
            }
    
            public bool InitQMgrAndQueue()
            {
                bool flag = true;
                Hashtable qMgrProp = new Hashtable();
                qMgrProp.Add(MQC.TRANSPORT_PROPERTY, MQC.TRANSPORT_MQSERIES_MANAGED);
                qMgrProp.Add(MQC.HOST_NAME_PROPERTY, ConfigurationManager.AppSettings["ConnectionName"]);
                qMgrProp.Add(MQC.CHANNEL_PROPERTY, ConfigurationManager.AppSettings["Channel"]);
    
                try
                {
                   if (ConfigurationManager.AppSettings["Port"] != null)
                      qMgrProp.Add(MQC.PORT_PROPERTY, System.Int32.Parse(ConfigurationManager.AppSettings["Port"]));
                   else
                      qMgrProp.Add(MQC.PORT_PROPERTY, 1414);
                }
                catch (System.FormatException e)
                {
                   qMgrProp.Add(MQC.PORT_PROPERTY, 1414);
                }
    
                if (ConfigurationManager.AppSettings["UserID"] != null)
                   qMgrProp.Add(MQC.USER_ID_PROPERTY, ConfigurationManager.AppSettings["UserID"]);
    
                if (ConfigurationManager.AppSettings["Password"] != null)
                   qMgrProp.Add(ConfigurationManager.AppSettings["Password"]);
    
                try
                {
                    qManager = new MQQueueManager(ConfigurationManager.AppSettings["QueueManager"],
                                                  qMgrProp);
                    System.Console.Out.WriteLine("Connected Successfully");
    
                    inQ = qManager.AccessQueue(ConfigurationManager.AppSettings["Queuename"],
                                                  MQC.MQOO_INPUT_AS_Q_DEF + MQC.MQOO_FAIL_IF_QUIESCING);
                    System.Console.Out.WriteLine("Open queue Successfully");
                }
                catch (MQException exp)
                {
                    System.Console.Out.WriteLine("MQException CC=" + mqex.CompletionCode + " : RC=" + mqex.ReasonCode);
                    flag = false;
                }
    
                return flag;
            }
    
            public void LoopThruMessages()
            {
                MQGetMessageOptions gmo = new MQGetMessageOptions();
                gmo.Options |= MQC.MQGMO_WAIT | MQC.MQGMO_FAIL_IF_QUIESCING;
                gmo.WaitInterval = 2500;  // 2.5 seconds wait time or use MQC.MQEI_UNLIMITED to wait forever
                MQMessage msg = null;
    
                while (running)
                {
                    try
                    {
                       msg = new MQMessage();
                       inQ.Get(msg, gmo);
                       System.Console.Out.WriteLine("Message Data: " + msg.ReadString(msg.MessageLength));
                    }
                    catch (MQException mqex)
                    {
                       if (mqex.Reason == MQC.MQRC_NO_MSG_AVAILABLE)
                       {
                          // no meesage - life is good - loop again
                       }
                       else
                       {
                          running = false;  // severe error - time to exit
                          System.Console.Out.WriteLine("MQException CC=" + mqex.CompletionCode + " : RC=" + mqex.ReasonCode);
                       }
                    }
                    catch (System.IO.IOException ioex)
                    {
                       System.Console.Out.WriteLine("ioex=" + ioex);
                    }
                }
    
                try
                {
                   if (inQ != null)
                   {
                      inQ.Close();
                      System.Console.Out.WriteLine("Closed queue");
                   }
                }
                catch (MQException mqex)
                {
                    System.Console.Out.WriteLine("MQException CC=" + mqex.CompletionCode + " : RC=" + mqex.ReasonCode);
                }
    
                try
                {
                   if (qMgr != null)
                   {
                      qMgr.Disconnect();
                      System.Console.Out.WriteLine("disconnected from queue manager");
                   }
                }
                catch (MQException mqex)
                {
                    System.Console.Out.WriteLine("MQException CC=" + mqex.CompletionCode + " : RC=" + mqex.ReasonCode);
                }
            }
    
            public void StopIt()
            {
                running = false;
            }
        }
    }
