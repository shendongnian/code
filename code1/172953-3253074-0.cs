    void DeleteUsable<Ttype>(IEnumerable<Ttype> usables, IEnumerable<Ttype> collection, Func<int, Ttype> load)
    {
         bool flag = false;
         foreach (dynamic usableCat in usables)
                    {
                        foreach (dynamic catRow in collection)
                        {
                            if (usableCat.ID == catRow.ID)
                                flag = true;
                        }
                        if (!flag)
                        {
                            int id = usableCat.ID;
                            Ttype resolution = load(id);
                            resolution.Delete(Services.UserServices.User);
                        }
                    }
    }
