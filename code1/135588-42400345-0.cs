    public class MyList<T> : List<T>
    {
        public override bool Equals(object obj)
        {
            if (obj == null)
                return false;
            MyList<T> list = obj as MyList<T>;
            if (list == null)
                return false;
            if (list.Count != this.Count)
                return false;
            bool same = true;
            this.ForEach(thisItem =>
            {
                if (same)
                {
                    same = (null != list.FirstOrDefault(item => item.Equals(thisItem)));
                }
            });
            return same;
        }
    }
