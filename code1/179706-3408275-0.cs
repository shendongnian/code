    void ProcessList(int start, int count) {
        for (int i=start; i < start + count; i++) {
            ProcessItem(i);
        }
    }
    void ProcessItem(int i) { // your code here
    }
    private void btnProcess_Click() {
       if (IsContinuous) {
          ProcessList(0, list.Count);
       }
       else {
           ProcessItem(0);
       }
    }
    private bool IsContinuous { get { return chkBox.Checked; } }
    
