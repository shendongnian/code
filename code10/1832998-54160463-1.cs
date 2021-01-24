    int c = 0;
    foreach (string st in File.ReadAllLines("path")) {
        string[] split = st.Split(' ');
        foreach (string s in split) {
            foreach (string line in File.ReadAllLines("path")) {
                if (line.Contains(s)) {
                    c++; 
                }
            }
        }
    }
