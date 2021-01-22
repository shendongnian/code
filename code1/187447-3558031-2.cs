    bool running = false;
    readonly object padlock = new object();
    
      void DataDisplayView_Paint(object sender, PaintEventArgs e)
      {
         
         if (!this.initialSetDone)
         {
            lock(padlock)
            {
              if(running) return;
              running = true;
            }
            try {
    
              //DOSOMETHING
            }
            finally
            {
              lock(padlock)
              {
                this.running = false;
              }
            }
         }
     }
