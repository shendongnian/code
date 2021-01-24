        public class ClassHandler<T> where T : BaseClass, new()
    {
        public void FillEntity(List<StorageFile> files, List<T> listToFill)
        {
            T obj = null;
            files.ForEach(file =>
            {
                switch (typeof(T).Name)
                {
                    case "BaseClass":
                        obj = new BaseClass(file.BaseProp) as T;
                        listToFill.Add(obj);
                        break;
                    case "DerievedClass":
                        obj = new DerievedClass(file.BaseProp, file.DerievedProp) as T;
                        listToFill.Add(obj);
                        break;
                };
            });           
        }
    }
