    class A<T>
        {
    
            List<Deserializer<T>> deserializers = new List<Deserializer<T>>();
    
            string Method1()
            {
                Command<string> cmd = new Command<string>();
                var a = (Deserializer<T>)Convert.ChangeType(cmd.Deserializer, typeof(T));
                this.deserializers.Add(a);
                //return "";
            }
            int Method2()
            {
                Command<int> cmd = new Command<int>();
                var a = (Deserializer<T>)Convert.ChangeType(cmd.Deserializer, typeof(T));
                this.deserializers.Add(a);
                //return 0;
            }
    
            void Execute()
            {
                Node node1 = new Node();
                string result1 = (string)Convert.ChangeType(this.deserializers[0].Deserialize(node1), typeof(T));
    
                Node node2 = new Node();
                int result2 = (int)Convert.ChangeType(this.deserializers[1].Deserialize(node2), typeof(T));
            }
        }
