    . . .
            public static TestSuiteInstrumentation CurrentInstrumentation { get; set; }
    
            public TestInstrumentation(IntPtr handle, JniHandleOwnership transfer) : base(handle, transfer)
            {
                CurrentInstrumentation = this;
            }
    . . .
