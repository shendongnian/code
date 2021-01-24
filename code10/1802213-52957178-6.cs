    static class Program
    {
        static void Main(string[] args)
        {
            var plugin = new MyModelPlugin();
            plugin.ChangesApplied += (m) => Debug.WriteLine(m.Initialized ? $"A={m.A}, B={m.B}" : "Uninitialized");
            // Uninitialized model
            var model = new MyModel();
            plugin.SetData(model);
            // Initialized model
            model = new MyModel(1, "Hello SO");
            plugin.SetData(model);
            // Make a copy and check equality
            var copy = plugin.Model;
            Debug.WriteLine($"Copy is identical = { copy == model }");
        }
    }
