        }
        public void consumer()
        {
            while (true)
            {
                pro.WaitOne();
               .................****
               
                con.Set();
            }
        }
        private void button1_Click(object sender, EventArgs e)
        {
            Thread th1 = new Thread(produser);
            th1.Start();
            Thread th2 = new Thread(consumer);
            th2.Start();
        }
