    public class FooCollection : Collection<Foo>
     { Dictionary<int,Foo> dict = new Dictionary<int,Foo>();
       public Foo GetById(int id) { return dict[id]; }
       public bool Contains(int id) { return  dict.Containskey(id);}
       
       protected override void InsertItem(Foo f)
        { dict[f.Id] = f;
          base.InsertItem(f);
        }
       protected override void ClearItems()
        { dict.Clear();
          base.ClearItems();
        }
       protected override void RemoveItem(int index)
        { dict.Remove(base.Items[index].Id);
          base.RemoveItem(index);
        }
       protected override void SetItem(int index, Foo item)
        { dict.Remove(base.Items[index].Id);
          dict[item.Id] = item;
          base.SetItem(index, item);
        }
     }
 
       
     }
