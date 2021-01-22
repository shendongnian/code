    private void button1_Click(object sender, EventArgs e)
            {
                //Create the Serialize object to save the class to an XML file
                XmlSerializer serializer = new XmlSerializer(typeof(ObjectTest));
                FileStream fs = new FileStream(@"C:\Objects.xml", FileMode.Create);
    
                try
                {
    
    
                    //Create new instances of each class to store the data
                    ObjectTest testing = new ObjectTest();
                    Items newItems = new Items();
                    Item newItem = new Item();
                    SearchFields newSearch = new SearchFields();
    
                    //Assign SearchField data
                    newSearch.searchName = "itemName";
                    newSearch.searchValue = "itemValue";
    
                    //Assign the item type
                    newItem.itemType = "delete";
    
                    //Create a new array of SearchField objects
                    SearchFields[] testSearch = { newSearch };
    
                    //Add the SearchField array to the Item class
                    newItem.searchfields = testSearch;
    
                    //Add the single Item class to the Items class
                    newItems.item = newItem;
    
                    //Create a new array of Items objects
                    Items[] testItems = { newItems };
    
                    //Add the Items array to the ObjectTest class
                    testing.items = testItems;
    
                    //Serialize the object
                    serializer.Serialize(fs, testing);
    
    
                }
                catch (Exception ex)
                {
                    MessageBox.Show("Error: " + ex.ToString());
                }
                finally
                {   
                    //close the objects
                    fs.Close();
                    serializer = null;
    
                }
    
                
                
            }
