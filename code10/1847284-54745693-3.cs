    class ItemComparer : Comparer<Item>
    {
         public static readonly ByCreatedDate = new ItemComparer();
         private static readonly IComparer<DateTime> dateComparer = Comparer<DateTime>.default;
         public override int CompareTo(Item x, Item y)
         {
             // TODO: decide what to do if x or y null: exception? comes first? comes last
             if (x.Announcement == null)
             {
                 if (y.Announcement == null)
                     // x and y both have null announcement
                     return 0;
                 else
                     // x.Announcement null, y.Announcement not null: x comes last:
                     return +1;
             }
             else
             {
                 if (y.Announcement == null)
                     // x.Announcement not null and y.Announcement null; x comes first
                     return -1;
                 else
                     // x.Announcement not null, y.Announcement not null: compare dates
                     return dateComparer.CompareTo(x.CreatedDate, y.CreateDate)
             }
        }
    }
