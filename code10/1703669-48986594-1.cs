    for(int i = 0; i<ListTag.Items.Count;i++)
    {
         string p = ListTag.Items[i].ToString();
         if (p == "value")
         {
              ListTag.SetSelected(i, true);
         }
    }
