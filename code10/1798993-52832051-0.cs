         public IEnumerator RefreshData()
           {
                //load the data
                //dataLoader is the link of the echoed php data
                WWW InventoryDatabase = new WWW(dataLoaderURL);
                //wait until its done dowloading
                yield return InventoryDatabase;
                 string temp = InventoryDatabase.text;
                        temp = temp.Replace("&lt;", "asdf");
                        temp = temp.Replace("&gt;", "<");
                        temp = temp.Replace("&amp;", "&");
                        temp = temp.Replace("&quot;", "\"");
                //this "Inventory" contains all the data from the echoed file
                string Inventory =  temp;
                string abc = InventoryDatabase.text;
                Debug.Log("text is: " + Inventory);
           }
