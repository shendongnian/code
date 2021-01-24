     class A
        {
    
            List<dynamic> deserializers = new List<dynamic>();
            //OR
            //List<object> deserializers = new List<object>();
    
            string Method1()
            {
                Command<string> cmd = new Command<string>();
                //var a = (T)Convert.ChangeType(cmd.Deserializer, typeof(T));
                this.deserializers.Add(cmd.Deserializer);
            }
            int Method2()
            {
                Command<int> cmd = new Command<int>();
                this.deserializers.Add(cmd.Deserializer);
            }
    
            void Execute()
            {
                string result = this.deserializers[0].Deserialize();
                int result2 = this.deserializers[1].Deserialize();
            }
        }
    
