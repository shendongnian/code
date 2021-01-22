    private string lastName;
    public string LastName
    {
        get
        {
            string s;
            if (lastName == null)
            {
                s = string.Empty;
            }
            else
            {
                s = item.LastName.Substring(0, item.LastName.Length > 30 ? 30 : item.LastName.Length);
            }
            return s;
        }
    }
