    public class A : DisposableObject
    {
        public Component components_a { get; set; }
        private IntPtr handle_a;
    
        protected override void DisposeManagedResources()
        {
            Console.WriteLine("A_DisposeManagedResources");
            components_a.Dispose();
            components_a = null;
            base.DisposeManagedResources();
        }
    
        protected override void DisposeUnmanagedResources()
        {
            Console.WriteLine("A_DisposeUnmanagedResources");
            CloseHandle(handle_a);
            handle_a = IntPtr.Zero;
            base.DisposeUnmanagedResources();
        }
    }
    public class B : A
    {
        public Component components_b { get; set; }
        private IntPtr handle_b;
    
        protected override void DisposeManagedResources()
        {
            Console.WriteLine("B_DisposeManagedResources");
            components_b.Dispose();
            components_b = null;
            base.DisposeManagedResources();
        }
    
        protected override void DisposeUnmanagedResources()
        {
            Console.WriteLine("B_DisposeUnmanagedResources");
            CloseHandle(handle_b);
            handle_b = IntPtr.Zero;
            base.DisposeUnmanagedResources();
        }
    }
