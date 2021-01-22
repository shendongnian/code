    byte[] bytes = new byte[] { 1, 2, 5, 0, 6 };
    byte[] another = new byte[] { 1, 2, 5, 0, 6 };
    string astring = "A string...";
    string bstring = "A string...";
            
    MessageBox.Show(bytes.GetHashCode() + " " + another.GetHashCode() + " | " + astring.GetHashCode() + " " + bstring.GetHashCode());
