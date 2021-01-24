    public class ListViewModel {
        public ObservableCollection<Student> StudentCollection => ...;
    }
    
    public class Student {
        public ObservableCollection<Stuff> Stuff => ... ; //["Physics", ...]
        public string SubListText => string.Join(", ", Stuff);
    }
