    using System;
    using System.Collections.Generic;
    using System.Linq;
    using System.Text;
    
    namespace ConsoleApplication1
    {
        class Program
        {
            static void Main(string[] args)
            {
                FakeMainForm form = new FakeMainForm();
                form.CreateComponentAndListenForMessage();
                Console.ReadKey(true);
            }
        }
    
        class FakeMainForm
        {
            public FakeMainForm()
            {
                Listener.AddListener(MessageRecieved);
            }
    
            void MessageRecieved(string msg)
            {
                Console.WriteLine("FakeMainForm.MessageRecieved: {0}", msg);
            }
    
            public void CreateComponentAndListenForMessage()
            {
                ComponentClass component = new ComponentClass();
                component.PretendToProcessData();
            }
        }
    
        class Listener
        {
            private static event Action<string> Notify;
    
            public static void AddListener(Action<string> handler)
            {
                Notify += handler;
            }
    
            public static void InvokeListener(string msg)
            {
                if (Notify != null) { Notify(msg); }
            }
        }
    
        class ComponentClass
        {
            public void PretendToProcessData()
            {
                Listener.InvokeListener("ComponentClass.PretendToProcessData() was called");
            }
        }
    }
