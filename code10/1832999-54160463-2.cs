    int c = 0;
    var st1 = File.ReadAllLines("path"); //the path to the first file
    var st2 = File.ReadAllLines("path"); //the path to the second file
    foreach (string line1 in st1) {
        foreach (string s in line1.Split(' ')) {
            foreach (string line2 in st2) {
                if (line2.Contains(s)) {
                    c++; 
                }
            }
        }
    }
