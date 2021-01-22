    public List<List<string>> str = new List<List<string>>();
    
    public void check() {
      List<string> subs = new List<string>();
      for (int i = 0; i < sub.Count; i++) {
        if (checkbx[i].Checked) {
          subs.Add(checkbx[i].Text);
        }
      }
      str.Add(subs);
    }
