    //loops through all list checkboxes 
     for(int index = 0; index <CategoryCBL.Items.Count; index++)
     {
         //gets the listcheck box string 
         string item = CategoryCBL.Items[index].ToString();
         //compare the list box string against the current Category looking for matches
         if (item == cat)
         {
             //if a match occures the list checkbox at that index is selected 
             CategoryCBL.Items[index].Selected= true;
             TextBox1.Text += item + "-" + cat + "-" + index;
         }
     }
