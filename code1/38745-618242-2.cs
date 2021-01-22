    using System;
    using System.Collections;
    
    public delegate void ProcessItem(Object i);
    public class DataBase : ArrayList {
        public DataBase() {}
        public void Scan(ProcessItem handler) {
            foreach (object o in this) {
                handler(o);
            }
        }
    }
    public interface IPrint {
        void print(string s);
    }
