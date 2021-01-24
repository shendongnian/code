    public class InvokeRequest
    {
        public string A { get; set; }
        public string B { get; set; }
        public string C { get; set; }
        public string D { get; set; }
        public string E { get; set; }
    }
    public async Task<IViewComponentResult> InvokeAsync(InvokeRequest request)
    {
        //...
    }
    @await Component.InvokeAsync("ViewComponent2", new InvokeRequest(){ A = Model.A, B = "B", C = Model.C, D = Model.D, E = "2" })
