     public delegate void MethodInvoker();
    
        private void Foo()
        {
            // sleep for 10 seconds.
            Thread.Sleep(10000);
        }
    
    protected void Button2_Click(object sender, EventArgs e)
    {
        // create a delegate of MethodInvoker poiting to
        // our Foo function.
        MethodInvoker simpleDelegate = new MethodInvoker(Foo);
        // Calling Foo Async
       simpleDelegate.BeginInvoke(null, null);
    }
