        public bool Kill = false;
        protected override void OnDoWork(DoWorkEventArgs e)
        {
           
        
            var _child = new Thread(() =>
            {
                while (!Kill)
                {
                }
                e.Cancel = true;//..Do Some Code
            });
            _child.Start();
            base.OnDoWork(e);
            
        }
        
        
    }
