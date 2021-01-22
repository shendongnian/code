    progressBar.Invoke(new MethodInvoker(UpdateProgressBarbyOne));
    ...
    
    private void UpdateProgressBarByOne() {
      progressBar.Value += 1;  
    }
