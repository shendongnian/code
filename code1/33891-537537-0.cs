    interface IA{
        void foo();
    }
    class CA : IA{
        public void foo(){
            Console.Writeline("Class A");
        }
    }
    class CB : CA, IA{
        public new void foo(){
            Console.Writeline("Class B");
        }
    }
