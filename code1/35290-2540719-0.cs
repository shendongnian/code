            T item = (T)Activator.CreateInstance(typeof(T));
            
            ((T)item as DemomigrItemList).Initialize();
            
            Type type = ((T)item as DemomigrItemList).AsEnumerable().FirstOrDefault().GetType();
            if (type == null) return;
            if (type != typeof(account)) //account is listitem in List<account>
            {
                ((T)item as DemomigrItemList).CreateCSV(type);
            }
        }
