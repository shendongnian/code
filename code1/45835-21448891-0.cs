        ...
        public static void BeginInvokeEx(this Action a){
            a.BeginInvoke(a.EndInvoke, a);
        }
        ...
        // Don't worry about EndInvoke
        // it will be called when finish
        new Action(() => {}).BeginInvokeEx(); 
