    interface A {
        void DoAThing();
    }
    interface B {
        void DoBThing();
    }
    class Mock : A {
        public void DoAThing() {
            //fake it till you make it       
        }
    }
    class DAL : A, B {
        //Way too many methods here
    }
