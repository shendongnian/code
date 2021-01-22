        static void Main() {
            var m_Map = new Dictionary<string, Action<object>>();
            m_Map.Add("Key1", obj => Console.WriteLine("Woohoo !{0}", obj));
            m_Map.Add("Key2", obj => SomeMethod((int)obj));
            m_Map["Key1"](123);
            m_Map["Key2"](123);
        }
        static void SomeMethod(int i) {
            Console.WriteLine("SomeMethod: {0}", i);
        }
