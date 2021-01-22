    class A{
        public event EventHandler Event1;
        public void TriggerEvent1(){
            if(Event1 != null)
                Event1(this, EventArgs.Empty);
        }
    }
    class B{
        static void HandleEvent(object o, EventArgs e){
            Console.WriteLine("Woo-hoo!");
        }
        static void AttachToEvent(Action<EventHandler> attach){
            attach(HandleEvent);
        }
        static void Main(){
            A a = new A();
            AttachToEvent(handler=>a.Event1 += handler);
            a.TriggerEvent1();
        }
    }
