     public void ReadingCollection(System.Collections.Generic.IEnumerable<ShowAvaQu> coll)
       {
            foreach (var id in coll)
            {               
                MyCustControl sc = (MyCustControl)this.FindName(id.xyID);
                switch (id.Status)
                {
                    case 1:
                        sc.Status = MyCustControl.Status.First;
                        break;
                    case 2:
                        sc.Status = MyCustControl.Status.Second;
                        break;
                    case 3:
                        sc.Status = MyCustControl.Status.Third;
                        break;
                    default:
                        break;
               }
            }
        }
