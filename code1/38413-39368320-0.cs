    using System;
    using System.Collections.Generic;
    using System.IO;
    using System.IO.Pipes;
    using System.Threading;
    using System.Windows;
    using System.Windows.Controls;
    namespace PIPESERVER
    {
        public partial class PWIN : UserControl
       {
        public string msg = "", cmd = "", text = "";
        public NamedPipeServerStream pipe;
        public NamedPipeClientStream dummyclient;
        public string PipeName = "PIPE1";
        public static string status = "";
        private static int numThreads = 2;
        int threadId;
        int i;
        string[] word;
        char[] buffer;
        public StreamString ss;
        public bool ConnectDummyClient()
        {
            new Thread(() =>
            {
                dummyclient = new NamedPipeClientStream(".", "PIPE1");
                try
                {
                    dummyclient.Connect(5000); // 5 second timeout
                }
                catch (Exception e)
                {
                    Act.m.md.AMsg(e.Message); // Display error msg
                    Act.m.console.PipeButton.IsChecked = false;
                }
            }).Start();
            return true;
        }
        public bool RaisePipe()
        {
            TextBlock tb = Act.m.tb;
            try
            {
                pipe = new NamedPipeServerStream("PIPE1", PipeDirection.InOut, numThreads);
                threadId = Thread.CurrentThread.ManagedThreadId;
                pipe.WaitForConnection();
                Act.m.md.Msg("Pipe Raised");
                return true;
            }
            catch (Exception e)
            {
                string err = e.Message;
                tb.Inlines.Add(new Run("Pipe Failed to Init on Server Side"));
                tb.Inlines.Add(new LineBreak());
                return false;
            }
        }
        public void ServerWaitForMessages()
        {
            new Thread(() =>
            {
                cmd = "";
                ss = new StreamString(pipe);
                while (cmd != "CLOSE")
                {
                    try
                    {
                        buffer = new char[256];
                        text = "";
                        msg = ss.ReadString().ToUpper();
                        word = msg.Split(' ');
                        cmd = word[0].ToUpper();
                        for (i = 1; i < word.Length; i++) text += word[i] + " ";
                        switch (cmd)
                        {
                            case "AUTHENTICATE": ss.WriteString("I am PIPE1 server"); break;
                            case "SOMEPIPEREQUEST":ss.WriteString(doSomePipeRequestReturningString()):break;
                            case "CLOSE": ss.WriteString("CLOSE");// reply to client
                                Thread.Sleep(1000);// wait for client to pick-up shutdown message
                                pipe.Close();
                                Act.m.md.Msg("Server Shutdown ok"); // Server side message
                                break;
                        }
                    }
                    catch (IOException iox)
                    {
                        string error = iox.Message;
                        Act.m.md.Msg(error);
                        break;
                    }
                }
            }).Start();
        }
        public void DummyClientCloseServerRequest()
        {
            StreamString ss = new StreamString(dummyclient);
            ss.WriteString("CLOSE");
            ss.ReadString();
        }
