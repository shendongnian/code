    <!-- language: c# -->
    var assemblyName = Assembly.GetExecutingAssembly().GetName();
    Console.WriteLine("{0}, PublicKey={1}",
        assemblyName.Name,
    string.Join("", assemblyName.GetPublicKey().Select(m => string.Format("{0:x2}", m))));
