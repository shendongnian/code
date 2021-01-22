        internal interface IPersist
        {
            void Save();
        }
        public class Concrete : IPersist
        {
            void IPersist.Save()
            {
                Console.WriteLine("Yeah!");
            }
        }
    
    // Mylist.cs in the same assembly can still call save like
    public void SaveItems()
        {
            foreach (IPersist item in this)
            {
                item.Save();
            }
        }
