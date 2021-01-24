    using System;
    using System.Collections;
    using System.Collections.Generic;
    using System.Text;
    using IBM.WMQ;
    
    /// <summary> Program Name
    /// MQTest62
    ///
    /// Description
    /// This C# class will connect to a remote queue manager
    /// and get messages from a queue using a managed .NET environment.
    ///
    /// Sample Command Line Parameters
    /// -h 127.0.0.1 -p 1415 -c TEST.CHL -m MQWT1 -q TEST.Q1 -u tester -x mypwd
    /// </summary>
    /// <author>  Roger Lacroix
    /// </author>
    namespace MQTest62
    {
       public class MQTest62
       {
          private Hashtable inParms = null;
          private Hashtable qMgrProp = null;
          private System.String qManager;
          private System.String inputQName;
    
          /*
          * The constructor
          */
          public MQTest62()
              : base()
          {
          }
    
          /// <summary> Make sure the required parameters are present.</summary>
          /// <returns> true/false
          /// </returns>
          private bool allParamsPresent()
          {
             bool b = inParms.ContainsKey("-h") && inParms.ContainsKey("-p") &&
                      inParms.ContainsKey("-c") && inParms.ContainsKey("-m") &&
                      inParms.ContainsKey("-q");
             if (b)
             {
                try
                {
                   System.Int32.Parse((System.String)inParms["-p"]);
                }
                catch (System.FormatException e)
                {
                   b = false;
                }
             }
    
             return b;
          }
    
          /// <summary> Extract the command-line parameters and initialize the MQ variables.</summary>
          /// <param name="args">
          /// </param>
          /// <throws>  IllegalArgumentException </throws>
          private void init(System.String[] args)
          {
             inParms = System.Collections.Hashtable.Synchronized(new System.Collections.Hashtable(14));
             if (args.Length > 0 && (args.Length % 2) == 0)
             {
                for (int i = 0; i < args.Length; i += 2)
                {
                   inParms[args[i]] = args[i + 1];
                }
             }
             else
             {
                throw new System.ArgumentException();
             }
    
             if (allParamsPresent())
             {
                qManager = ((System.String)inParms["-m"]);
                inputQName = ((System.String)inParms["-q"]);
    
                qMgrProp = new Hashtable();
                qMgrProp.Add(MQC.TRANSPORT_PROPERTY, MQC.TRANSPORT_MQSERIES_MANAGED);
    
                qMgrProp.Add(MQC.HOST_NAME_PROPERTY, ((System.String)inParms["-h"]));
                qMgrProp.Add(MQC.CHANNEL_PROPERTY, ((System.String)inParms["-c"]));
    
                try
                {
                   qMgrProp.Add(MQC.PORT_PROPERTY, System.Int32.Parse((System.String)inParms["-p"]));
                }
                catch (System.FormatException e)
                {
                   qMgrProp.Add(MQC.PORT_PROPERTY, 1414);
                }
    
                if (inParms.ContainsKey("-u"))
                   qMgrProp.Add(MQC.USER_ID_PROPERTY, ((System.String)inParms["-u"]));
    
                if (inParms.ContainsKey("-x"))
                   qMgrProp.Add(MQC.PASSWORD_PROPERTY, ((System.String)inParms["-x"]));
    
                System.Console.Out.WriteLine("MQTest62:");
                Console.WriteLine("  QMgrName ='{0}'", qManager);
                Console.WriteLine("  Output QName ='{0}'", inputQName);
    
                System.Console.Out.WriteLine("QMgr Property values:");
                foreach (DictionaryEntry de in qMgrProp)
                {
                   Console.WriteLine("  {0} = '{1}'", de.Key, de.Value);
                }
             }
             else
             {
                throw new System.ArgumentException();
             }
          }
    
          /// <summary> Connect, open queue, read (browse) a message, close queue and disconnect. </summary>
          ///
          private void testReceive()
          {
             MQQueueManager qMgr = null;
             MQQueue inQ = null;
             int openOptions = MQC.MQOO_INPUT_AS_Q_DEF + MQC.MQOO_FAIL_IF_QUIESCING;
    
             try
             {
                qMgr = new MQQueueManager(qManager, qMgrProp);
                System.Console.Out.WriteLine("MQTest62 successfully connected to " + qManager);
    
                inQ = qMgr.AccessQueue(inputQName, openOptions);
                System.Console.Out.WriteLine("MQTest62 successfully opened " + inputQName);
    
                testLoop(inQ);
    
             }
             catch (MQException mqex)
             {
                System.Console.Out.WriteLine("MQTest62 cc=" + mqex.CompletionCode + " : rc=" + mqex.ReasonCode);
             }
             catch (System.IO.IOException ioex)
             {
                System.Console.Out.WriteLine("MQTest62 ioex=" + ioex);
             }
             finally
             {
                try
                {
                   if (inQ != null)
                      inQ.Close();
                   System.Console.Out.WriteLine("MQTest62 closed: " + inputQName);
                }
                catch (MQException mqex)
                {
                   System.Console.Out.WriteLine("MQTest62 cc=" + mqex.CompletionCode + " : rc=" + mqex.ReasonCode);
                }
    
                try
                {
                   if (qMgr != null)
                      qMgr.Disconnect();
                   System.Console.Out.WriteLine("MQTest62 disconnected from " + qManager);
                }
                catch (MQException mqex)
                {
                   System.Console.Out.WriteLine("MQTest62 cc=" + mqex.CompletionCode + " : rc=" + mqex.ReasonCode);
                }
             }
          }
    
          private void testLoop(MQQueue inQ)
          {
             bool flag = true;
             MQGetMessageOptions gmo = new MQGetMessageOptions();
             gmo.Options |= MQC.MQGMO_WAIT | MQC.MQGMO_FAIL_IF_QUIESCING;
             gmo.WaitInterval = 2500;  // 2.5 seconds wait time or use MQC.MQEI_UNLIMITED to wait forever
             MQMessage msg = null;
    
             while (flag)
             {
                try
                {
                   msg = new MQMessage();
                   inQ.Get(msg, gmo);
                   System.Console.Out.WriteLine("Message Data: " + msg.ReadString(msg.MessageLength));
                }
                catch (MQException mqex)
                {
                   System.Console.Out.WriteLine("MQTest62 CC=" + mqex.CompletionCode + " : RC=" + mqex.ReasonCode);
                   if (mqex.Reason == MQC.MQRC_NO_MSG_AVAILABLE)
                   {
                      // no meesage - life is good - loop again
                   }
                   else
                   {
                      flag = false;  // severe error - time to exit
                   }
                }
                catch (System.IO.IOException ioex)
                {
                   System.Console.Out.WriteLine("MQTest62 ioex=" + ioex);
                }
             }
          }
    
          /// <summary> main line</summary>
          /// <param name="args">
          /// </param>
          //        [STAThread]
          public static void Main(System.String[] args)
          {
             MQTest62 write = new MQTest62();
    
             try
             {
                write.init(args);
                write.testReceive();
             }
             catch (System.ArgumentException e)
             {
                System.Console.Out.WriteLine("Usage: MQTest62 -h host -p port -c channel -m QueueManagerName -q QueueName [-u userID] [-x passwd]");
                System.Environment.Exit(1);
             }
             catch (MQException e)
             {
                System.Console.Out.WriteLine(e);
                System.Environment.Exit(1);
             }
    
             System.Environment.Exit(0);
          }
       }
    }
