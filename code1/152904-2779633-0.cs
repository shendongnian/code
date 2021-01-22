            public delegate void BigEventHandler(object sender, EventArgs e);
    
            public event BigEventHandler SomeThingBigHappened;
           
    
            private void button1_Click(object sender, EventArgs e)
            {
                OnSomeThingBigHappened(e);
            }
    
            protected virtual void OnSomeThingBigHappened(EventArgs e)
            {
                SomeThingBigHappened(this, e);
            }
