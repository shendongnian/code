    public class FilterTest
    {
        private FilterCollection filters = new FilterCollection();
        public void ApplyFilters(ref Mat buffer)
        {
            var filter = new GaussianBlur(new GaussianBlurParams { KernelSize = new Size(6, 6) });
            filters.Enqueue(filter);
            filters.Apply(ref buffer);
        }
    }
