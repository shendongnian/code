    private readonly Stopwatch stopwatch = new Stopwatch();
    public void OnSignIn(int pin) {
        if (this.pin == pin && !this.SignIn) {
            stopwatch.Reset();
            stopwatch.Start();
        } else if (this.pin != pin) {
            MessageBox.Show("Incorrect pin or already logged in");
        }
    }
    
    public void OnSignOut (int pin) {
        if (this.pin == pin && this.SignIn) {
            stopwatch.Stop();        
        } else {
            MessageBox.Show("Error!");
        }
    }
