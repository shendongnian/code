      delegate void AddListItemDelegate(string name,object otherInfoNeeded);
      private void
         AddListItem(
            string name,
            object otherInfoNeeded
         )
      {
         if (InvokeRequired)
         {
            BeginInvoke(new AddListItemDelegate(AddListItem), name, otherInfoNeeded
            return;
         }
         
         ... add code to create list box item and insert in list here ...
      }
