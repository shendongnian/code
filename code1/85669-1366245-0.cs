    List<string> stuff = new List<string>();
    for(int i = 0 ; i < 50000 ; i++) {
        stuff.Add(i.ToString());
        if((i % 100) == 0) {
            // update UI
            BeginInvoke((MethodInvoker) delegate {
                foreach(string s in stuff) {
                    listBox.Items.Add(s);
                }
            });
        }
    }
