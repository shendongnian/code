    public class IndexViewData : MasterViewData
    {
        public string Name { get; set; }
        public float Price { get; set; }
        public SubViewData SubViewData { get; set; }
    }
    <% Html.RenderPartial("Sub", Model.SubViewData); %>
