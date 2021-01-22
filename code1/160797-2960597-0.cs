    Process p = Process.Start(...);
    p.Exited += OnProcessExited;
    
    private void OnProcessExited(object sender, EventArgs e) {
      // Put code here
    }
