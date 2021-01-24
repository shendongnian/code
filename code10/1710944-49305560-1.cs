    using System;
    using System.Collections.Generic;
    using System.ComponentModel;
    using System.Data;
    using System.Drawing;
    using System.Linq;
    using System.Text;
    using System.Windows.Forms;
    using System.Threading;
    using System.Net;
    using System.Net.Sockets;
    using System.Net.NetworkInformation;
    namespace WindowsFormsApplication13
    {
        public partial class Form1 : Form
        {
             public Form1()
            {
                InitializeComponent();
     
            }
        }
        public class State
        {
            public string ip { get; set;}
            public decimal roundTripTime { get; set; }
            public IPStatus status { get;set;}
        }
        public class myPing
        {
            static const int NUMBER_SERVERS = 110;
            public static List<State> states { get; set; }
            public static int count = 0;
            public myPing()
            {
                AutoResetEvent waiter = new AutoResetEvent(false);
                for (int server = 1; server <= NUMBER_SERVERS; server++)
                {
                    string hostname = "oldschool" + server.ToString() + ".runescape.com";
                    // Get an object that will block the main thread.
                    // Ping's the local machine.
                    Ping pingSender = new Ping();
                    
                    // When the PingCompleted event is raised,
                    // the PingCompletedCallback method is called.
                    pingSender.PingCompleted += new PingCompletedEventHandler(PingCompletedCallback);
                    // Create a buffer of 32 bytes of data to be transmitted.
                    string data = "aaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaa";
                    byte[] buffer = Encoding.ASCII.GetBytes(data);
                    //Console.WriteLine("Send Before Async.");
                    // Send the ping asynchronously.
                    // Use the waiter as the user token.
                    // When the callback completes, it can wake up this thread.
                    pingSender.SendAsync(hostname, 1000, waiter);
                    //Console.WriteLine("Ping example completed.");
                }
                waiter.WaitOne();
                DisplayReply(states);
                Console.ReadLine();
            }
            private static void PingCompletedCallback(object sender, PingCompletedEventArgs e)
            {
                // If the operation was canceled, display a message to the user.
                if (e.Cancelled)
                {
                    Console.WriteLine("Ping canceled.");
                    // Let the main thread resume. 
                    // UserToken is the AutoResetEvent object that the main thread 
                    // is waiting for.
                    ((AutoResetEvent)e.UserState).Set();
                }
                // If an error occurred, display the exception to the user.
                if (e.Error != null)
                {
                    Console.WriteLine("Ping failed:");
                    Console.WriteLine(e.Error.ToString());
                    // Let the main thread resume. 
                    ((AutoResetEvent)e.UserState).Set();
                }
                PingReply reply = e.Reply;
                State state = new State();
                Object thisLock = new Object();
                lock (thisLock)
                {
                   states.Add(state);
                }
                state.ip = reply.Address.ToString();
                state.roundTripTime = reply.RoundtripTime;
                state.status = reply.Status;
                count++;
                // Let the main thread resume.
                if (count == NUMBER_SERVERS)
                {
                    ((AutoResetEvent)e.UserState).Set();
                }
            }
            public static void DisplayReply(List<State> replies)
            {
                foreach (State reply in replies)
                {
                    Console.WriteLine("Status: {0}", reply.status);
                    if (reply.status == IPStatus.Success)
                    {
                        Console.WriteLine("\r\n");
                        Console.WriteLine("Address: {0}", reply.ip);
                        Console.WriteLine("Ping: {0}", reply.roundTripTime);
                    }
                }
                State shortest = replies.OrderBy(x => x.roundTripTime).FirstOrDefault();
                Console.WriteLine("Shortest Route IP : '{0}'  Time : '{1}'", shortest.ip.ToString(), shortest.roundTripTime.ToString() );
            }
        }
     
    }
