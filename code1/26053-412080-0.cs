    private void Invisibilize(TimeSpan Duration)
        {
            (new System.Threading.Thread(() => { 
                this.Invoke(new MethodInvoker(this.Hide));
                System.Threading.Thread.Sleep(Duration); 
                this.Invoke(new MethodInvoker(this.Show)); 
                })).Start();
        }
