    // better idea is to have this as class property,
    // than creating it everytime you want to use it
    Random r = new Random();
    // Here you could use one of methods: AddSeconds, AddMinutes, etc.,
    // Choose one that fits best. Also you could choose othe base date
    // than DateTime.MinValue
    DateTime d = DateTime.MinValue.AddSeconds(r.Next());
    label1.Text = d.ToString();
