    mylst.Sort((i, j) =>
                  {
                      Debug.Assert(i.SomeProp != null && j.SomeProp != null);
                      return i.SomeProp.CompareTo(j.SomeProp);
                  }
             );
