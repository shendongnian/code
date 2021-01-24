    private Timer t2 = new Timer();
    		private bool startButtonWasClicked = false;
    
    		private void Form2_Load(object sender, EventArgs e)
    		{
    			//if the start button isn't pressed, in 5 seconds, Form2 closes and Form1 opens
    			if (!startButtonWasClicked)
    			{
    				t2.Interval = 5000;
    				t2.Tick += new EventHandler(OnTimerTicker);
    				t2.Start();
    			}
    			//else start button is clicked
    		}
    
    		
    
    		private void button1_Click(object sender, EventArgs e)
    		{
    			startButtonWasClicked = true;
    			// Stop the timer so it doesn't still run
    			t2.Stop();
    
    			bool IsOpen = false;
    			foreach (Form f in Application.OpenForms)
    			{
    				if (f.Text == "Form1")
    				{
    					IsOpen = true;
    					f.Focus();
    					break;
    					//if the form is already open, it will focus on that form
    				}
    			}
    
    			if (IsOpen == false)
    			{
    				Form1 f1 = new Form1();
    				f1.Show();
    			}
    
    			// Hide this window to be consistent
    			this.Hide();
    		}
    
    		private void OnTimerTicker(object sender, EventArgs e)
    		{
    			if (startButtonWasClicked) { return; }
    			t2.Stop();
    			Form1 f1 = new Form1();
    			this.Hide();//"closes form 2 after 5 seconds and opens form 1
    			f1.Show();
    
    		}
