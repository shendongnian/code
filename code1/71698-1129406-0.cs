    Picture test1 = new Picture() { Name = "Size: 54", Size = 54 };
    Picture test2 = new Picture() { Name = "Size: 10", Size = 10 };
                    
    this.listView1.ListViewItemSorter = test1;
        
    this.listView1.Items.Add(new ListViewItem(test1.Name) { Tag = test1 });
    this.listView1.Items.Add(new ListViewItem(test2.Name) { Tag = test2 });
     public class Picture : IComparer
        {
            public string Name { get; set; }
            public int Size { get; set; }
    
            #region IComparer Members
    
            public int Compare(object x, object y)
            {
                Picture itemA = ((ListViewItem)x).Tag as Picture;
                Picture itemB = ((ListViewItem)y).Tag as Picture;
    
                if (itemA.Size < itemB.Size)
                    return -1;
    
                if (itemA.Size > itemB.Size)
                    return 1;
    
                if (itemA.Size == itemB.Size)
                    return 0;
    
                return 0;
                
            }
