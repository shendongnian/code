        public class test {
        Action<int> CallUserCode;
        
        public test(Action<int> proc){
            CallUserCode = proc;
        }
        
        void foo(){
            int someValue = 0;
            //do some stuff that needs to call the user procedure
            CallUserCode(someValue);
        }
    }
