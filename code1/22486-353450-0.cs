    class MyClass {
       IntPtr hwnd;
       public MyClass(IntPtr hwnd) {
          this.hwnd = hwnd;
       }
       ...
       private void DoStuff()
       {
           //n.b. we don't necessarily know if the handle is still valid
           DoSomethingWithTheHandle(myHwnd);
       }
    }
