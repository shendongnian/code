    private void closinginvoker(string dummy)
        {
            if (InvokeRequired)
            {
                this.Invoke(new Action<string>(closinginvoker), new object[] { dummy });
                return;
            }
            t_listen.Abort();
            client_flag = true;
            c_idle.Close();
            listener1.Stop();
        }
