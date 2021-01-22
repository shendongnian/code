    class S {}
    class T : S {}
    class B {
        virtual S P { get; set; }
    }
    class D : B {
        override T P { get; set; }
    }
