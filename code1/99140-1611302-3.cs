    public class ExtendedList<T> : List<T>
    {
        public new void Add(T t)
        {
            base.Add(t);
            base.Sort();
        }
    }
    //sorting on each Add
    ExtendedList<string> dinosaurs = new ExtendedList<string>();
    
    dinosaurs.Add("Pachycephalosaurus"); 
    dinosaurs.Add("Amargasaurus");  
    dinosaurs.Add("Mamenchisaurus");
    dinosaurs.Add("Deinonychus");
