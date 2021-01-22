    class $$MyMethod$$Closure { 
      public int x;
      void Function(object sender, EventArgs e) {
        MessageBox.Show((x++).ToString());
      }
    }
    private void MyMethod() {
        var $$closure = new $$MyMethod$$Closure();
        $$closure.x = 1; 
        System.Timers.Timer t = new System.Timers.Timer(1000); 
        t.Elapsed += $$closure.LambdaFunction; 
        t.Start(); 
    }
