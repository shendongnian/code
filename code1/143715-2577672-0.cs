    void UpdateUI() {
        if (this.yourControl.InvokeRequired) {
            object[] ob = new object[] { targetX, targetY };
            UpdateUIDelegate updDel = new UpdateUIDelegate(RunMotors);
            this.yourControl.Invoke(updDel, ob);
        }
        else {
            this.RunMotors(targetX, targetY);
        }
    }
    
    void RunMotors(targetX, targetY)
    {
        // action
    }
