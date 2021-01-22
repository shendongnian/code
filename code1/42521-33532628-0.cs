        //Say you are calling some FUNC1 that has the tight while loop and you need to 
        //get updates on what percentage the updates have been done.
        private void ExecuteUpdates()
        {
            Func1(Info => { lblUpdInfo.Text = Info; });
        }
        //Now Func1 would keep calling back the Action specified in the argument
        //This System.Action can be returned for any type by passing the Type as the template.
        //This example is returning string.
        private void Func1(System.Action<string> UpdateInfo)
        {
            int nCount = 0;
            while (nCount < 100)
            {
                nCount++;
                if (UpdateInfo != null) UpdateInfo("Counter: " + nCount.ToString());
                //System.Threading.Thread.Sleep(1000);
            }
        }
