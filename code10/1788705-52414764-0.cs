    var items = Herojai.Where(i => i.Jėga == i.Intelektas || i.Jėga == i.Vikrumas || i.Intelektas == i.Vikrumas)
                       .Select(i => i.Vardas);
    using (var sw = new StreamWriter(@"xxx.csv"))
    {
        foreaach(var item in items)
        {
            sw.WriteLine(item);
        }
    }
