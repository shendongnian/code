    public string LookupMember {
           get {
                try {
                    return listBox1.SelectedValue.ToString();
                }
                catch { return null; }
            }
            set => listBox1.SelectedValue = value;
        }
