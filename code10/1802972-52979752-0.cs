    public void OutputNotification(String _time, String _type, String _data)
        {
            lock (_locker)
            {
                notifyShare = new SharedData();
                notifyShare.notifyTime = _time;
                notifyShare.notifyType = _type;
                notifyShare.notifyData = _data;
                sharedQueue.Enqueue(notifyShare);
                this.Context.Post(new SendOrPostCallback(notificationUpdate), null);  
            }       
        }
        public void notificationUpdate(object state)
        {
            if (sharedQueue.Count > 0)
            {
                SharedData temp = (SharedData)sharedQueue.Dequeue();
                form.UpdateNotifications(temp);
            }
        }
