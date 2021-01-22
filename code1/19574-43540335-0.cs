    mynode.NodeFont = new System.Drawing.Font("Consolas", 9,FontStyle.Regular);
    string displaytext = String.Format(CultureInfo.InvariantCulture, "{0}{2} = {1}", mystringOfDifferentLenght, myresult, GetEmptyInfoByIndex(mystringOfDifferentLength, 20));
    mynode.Text = displaytext;
    rootnode.Nodes.Add(mynode);
    private string GetEmptyInfoByIndex(string _string, int maxLength)
        {
            string retstr = string.Empty;
            for (int i = 0; i < maxLength - _string.Length; i++)
            {
                retstr += " ";
            }
            return retstr;
        }
