    public class ElementNameList : List<ElementNameViewModel> {
        public int X { get; set; }
    }
    
    var list = new List<ElementNameViewModel>();
    ElementNameList elementList = (ElementNameList) list;
    int x = elementList.X; // List<ElementNameViewModel> doesn't have 'X' property, what would happen here?
