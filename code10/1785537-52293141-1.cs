     foreach (int index in checkedListBox.CheckedIndices) {
       string taskName = Convert.ToString(checkedListBox[index]);
       
       // Now you have item index and item text (which is taskName). Let's try filling the list
       // We can try finding the item by string
       for (var item in m_objPCRCheck) {
         if (item.taskname == taskName) {
           m_objCheckeditem.Add(item);
           break; 
         } 
       }
  
       // Or (alternatively) you can trying to get index-th item:
       // m_objCheckeditem.Add(m_objPCRCheck[index]);
     }
