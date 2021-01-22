    public class Mediator {
        
        public void Add(A List, B Object) {
            if(list.Add(Object)) {
                object.Add(List);
            }
        }
        public void Delete(A List, B Object) {
            if(List.Delete(Object)) {
                Object.Delete(List);
            }
        }
    }
