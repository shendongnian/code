    internal class Publisher
    {
        internal event EventHandler<EventArgs> Publish;
        internal bool IsRegistered(Type type)
        {
            if (Publish == null) return false;
            //
            return (from item in Publish.GetInvocationList() where item.Target == null & item.Method.DeclaringType == type select item).Count() > 0;
        }
        internal bool IsRegistered(object instance)
        {
            if (Publish == null) return false;
            //
            return (from item in Publish.GetInvocationList() where item.Target == instance select item).Count() > 0;
        }
        static int Main(string[] args)
        {
            Publisher p = new Publisher();
            //
            p.Publish += new EventHandler<EventArgs>(static_Publish);
            p.Publish += new EventHandler<EventArgs>(p.instance_Publish);            
            //
            Console.WriteLine("eventhandler static_Publish attach: {0}", p.IsRegistered(typeof(Program)));
            Console.WriteLine("eventhandler instance_Publish attach: {0}", p.IsRegistered(program));
            //
            return 0;
        }
        void instance_Publish(object sender, EventArgs e)
        {
        }
        static void static_Publish(object sender, EventArgs e)
        {
        }
    }`
