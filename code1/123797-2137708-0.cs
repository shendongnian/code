    public class Widgets : List<Widgets> // Widgest class defined elsewhere
    {
        public Widgets() : base() {}
        public Widgets(IEnumerable<Widgets> items) : base(items) {}
        public Widget GetWidgetById(int id)
        {
            // assuming only one ID possible
            return this.Where(w => w.id == id).Single(); 
        }
        public string[] GetAllNames()
        {
            return this.Select(w => w.Name).ToArray();
        }
    }
    //... later in some other class ....
    Widgets w = new Widgets(dataFromDatabase);
    Widget customerWidget = w.GetWidgetById(customerWidgetId);
    string[] allNames = w.GetAllNames();
