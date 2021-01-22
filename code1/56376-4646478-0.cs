    public void MethodHashTable()
    {
        Hashtable objHashTable = new Hashtable();
        objHashTable.Add(1, 100);    // int
        objHashTable.Add(2.99, 200); // float
        objHashTable.Add('A', 300);  // char
        objHashTable.Add("4", 400);  // string
        
        lblDisplay1.Text = objHashTable[1].ToString();
        lblDisplay2.Text = objHashTable[2.99].ToString();
        lblDisplay3.Text = objHashTable['A'].ToString();
        lblDisplay4.Text = objHashTable["4"].ToString();
        
        // ----------- Not Possible for HashTable ----------
        //foreach (KeyValuePair<string, int> pair in objHashTable)
        //{
        //    lblDisplay.Text = pair.Value + " " + lblDisplay.Text;
        //}
    }
