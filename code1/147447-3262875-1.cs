      using System;
      using System.Collections.Generic;
      using System.Text;
      using System.Drawing.Color;
    
      namespace MSNRobot
      {
        using MSNPSharp;
        using MSNPSharp.Core;
        using MSNPSharp.DataTransfer;
    
        class RobotConversation
        {
            private Conversation _conversation = null;
            private RobotMain _robotmain = null;
    
            public RobotConversation(Conversation conv, RobotMain robotmain)
            {
                Console.WriteLine("==> Struct a conversation");
                _conversation = conv;
                _conversation.Switchboard.TextMessageReceived += new EventHandler<TextMessageEventArgs>(Switchboard_TextMessageReceived);
                _conversation.Switchboard.SessionClosed += new EventHandler<EventArgs>(Switchboard_SessionClosed);
                _conversation.Switchboard.ContactLeft += new EventHandler<ContactEventArgs>(Switchboard_ContactLeft);
                _robotmain = robotmain;
            }
    
            //online status
            private void Switchboard_TextMessageReceived(object sender, TextMessageEventArgs e)
            {
                Console.WriteLine("==>Received Msg From " + e.Sender.Mail + " Content:\n" + e.Message.Text);
    
                //echo back ///////////// TODO /////////////////
                _conversation.Switchboard.SendTextMessage(e.Message);
            }
    
            private void Switchboard_SessionClosed(object sender, EventArgs e)
            {
                Console.WriteLine("==>Session Closed, Remove conversation");
                _conversation.Switchboard.Close();
                _conversation = null;
                _robotmain.RobotConvlist.Remove(this);
            }
    
            private void Switchboard_ContactLeft(object sender, ContactEventArgs e)
            {
                Console.WriteLine("==>Contact Left.");
            }
        }
    
        class RobotMain
        {
            private Messenger messenger = new Messenger();
            private List<RobotConversation> _convs = new List<RobotConversation>(0);
    
            public RobotMain()
            {
                messenger.NameserverProcessor.ConnectionEstablished += new EventHandler<EventArgs>(NameserverProcessor_ConnectionEstablished);
                messenger.Nameserver.SignedIn += new EventHandler<EventArgs>(Nameserver_SignedIn);
                messenger.Nameserver.SignedOff += new EventHandler<SignedOffEventArgs>(Nameserver_SignedOff);
                messenger.NameserverProcessor.ConnectingException += new EventHandler<ExceptionEventArgs>(NameserverProcessor_ConnectingException);
                messenger.Nameserver.ExceptionOccurred += new EventHandler<ExceptionEventArgs>(Nameserver_ExceptionOccurred);
                messenger.Nameserver.AuthenticationError += new EventHandler<ExceptionEventArgs>(Nameserver_AuthenticationError);
                messenger.Nameserver.ServerErrorReceived += new EventHandler<MSNErrorEventArgs>(Nameserver_ServerErrorReceived);
                messenger.Nameserver.ContactService.ReverseAdded += new EventHandler<ContactEventArgs>(Nameserver_ReverseAdded);
                messenger.ConversationCreated += new EventHandler<ConversationCreatedEventArgs>(messenger_ConversationCreated);
                messenger.Nameserver.OIMService.OIMReceived += new EventHandler<OIMReceivedEventArgs>(Nameserver_OIMReceived);
                messenger.Nameserver.OIMService.OIMSendCompleted += new EventHandler<OIMSendCompletedEventArgs>(OIMService_OIMSendCompleted);
            }
    
            public List<RobotConversation> RobotConvlist
            {
                get
                {
                    return _convs;
                }
            }
    
            private void NameserverProcessor_ConnectionEstablished(object sender, EventArgs e)
            {
                //messenger.Nameserver.AutoSynchronize = true;
                Console.WriteLine("==>Connection established!");
            }
    
            private void Nameserver_SignedIn(object sender, EventArgs e)
            {
                messenger.Owner.Status = PresenceStatus.Online;
                Console.WriteLine("==>Signed into the messenger network as " + messenger.Owner.Name);
            }
    
            private void Nameserver_SignedOff(object sender, SignedOffEventArgs e)
            {
                Console.WriteLine("==>Signed off from the messenger network");
            }
    
            private void NameserverProcessor_ConnectingException(object sender, ExceptionEventArgs e)
            {
                //MessageBox.Show(e.Exception.ToString(), "Connecting exception");
                Console.WriteLine("==>Connecting failed");
            }
    
            private void Nameserver_ExceptionOccurred(object sender, ExceptionEventArgs e)
            {
                // ignore the unauthorized exception, since we're handling that error in another method.
                if (e.Exception is UnauthorizedException)
                    return;
    
                Console.WriteLine("==>Nameserver exception:" + e.Exception.ToString());
            }
    
            private void Nameserver_AuthenticationError(object sender, ExceptionEventArgs e)
            {
                Console.WriteLine("==>Authentication failed:" + e.Exception.InnerException.Message);
            }
    
            private void Nameserver_ServerErrorReceived(object sender, MSNErrorEventArgs e)
            {
                // when the MSN server sends an error code we want to be notified.
                Console.WriteLine("==>Server error received:" + e.MSNError.ToString());
            }
    
            void Nameserver_ReverseAdded(object sender, ContactEventArgs e)
            {
                //Contact contact = e.Contact;
                //contact.OnAllowedList = true;
                //contact.OnPendingList = false;
                //messenger.Nameserver.ContactService.AddNewContact(contact.Mail);
    
                Console.WriteLine("==>ReverseAdded contact mail:" + e.Contact.Mail);
    
                //messenger.Nameserver.AddNewContact(
                e.Contact.OnAllowedList = true;
                e.Contact.OnForwardList = true;
    
            }
    
            private void messenger_ConversationCreated(object sender, ConversationCreatedEventArgs e)
            {
                Console.WriteLine("==>Conversation created");
                _convs.Add(new RobotConversation(e.Conversation, this));
            }
    
          
    
            //offline status
            void Nameserver_OIMReceived(object sender, OIMReceivedEventArgs e)
            {
                Console.WriteLine("==>OIM received at : " + e.ReceivedTime + " From : " +
                    e.NickName + " (" + e.Email + ") " + e.Message);
    
                TextMessage message = new TextMessage(e.Message);
                message.Font = "Trebuchet MS";
                //message.Color = Color.Brown;
                message.Decorations = TextDecorations.Bold;
                Console.WriteLine("==>Echo back");
                messenger.OIMService.SendOIMMessage(e.Email, message.Text);
            }
    
            void OIMService_OIMSendCompleted(object sender, OIMSendCompletedEventArgs e)
            {
                if (e.Error != null)
                {
                    Console.WriteLine("OIM Send Error:" + e.Error.Message);
                }
            }
    
            public void BeginLogin(string account, string password)
            {
                if (messenger.Connected)
                {
                    Console.WriteLine("==>Disconnecting from server");
                    messenger.Disconnect();
                }
    
                // set the credentials, this is ofcourse something every MSNPSharp program will need to implement.
                messenger.Credentials = new Credentials(account, password, MsnProtocol.MSNP16);
    
    
                // inform the user what is happening and try to connecto to the messenger network.  
                Console.WriteLine("==>Connecting to server...");
                messenger.Connect();
    
                //displayImageBox.Image = global::MSNPSharpClient.Properties.Resources.loading;
    
                //loginButton.Tag = 1;
                //loginButton.Text = "Cancel";
    
                // note that Messenger.Connect() will run in a seperate thread and return immediately.
                // it will fire events that informs you about the status of the connection attempt.
                // these events are registered in the constructor.
            }
    
            /// <summary>
            /// main()
            /// </summary>
            /// <param name="args"></param>
            static void Main(string[] args)
            {
                string robot_acc = "";
                string robot_passwd = "";
    
                if (args.Length == 0)
                {
                    Console.WriteLine("USAGE:MSNRobot.exe <msn_account> [password]");    
                    return;
                }
    
                robot_acc = args[0];
    
                if (args.Length == 2)
                    robot_passwd = args[1];
                else
                {
                    Console.WriteLine("Password for " + robot_acc + ":");
                    robot_passwd = Console.ReadLine();
                }
    
                RobotMain app = new RobotMain();
                app.BeginLogin(robot_acc, robot_passwd);
               
                while (true)
                {
                    Console.WriteLine("I am a MSN robot:" + robot_acc);
                    Console.ReadLine();
                }
            }
        }
    }
