    public string RemoveSpecial(string evalstr)
    {
    StringBuilder finalstr = new StringBuilder();
                foreach(char c in evalstr){
                int charassci = Convert.ToInt16(c);
                if (!(charassci >= 33 && charassci <= 47))// special char ???
                 finalstr.append(c);
                }
    return finalstr.ToString();
    }
