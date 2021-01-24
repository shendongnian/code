    // suppose you have a sequence of tasks:
    IEnumerable<Task> tasks = ...
    // put it in a Tasks object, so you have a DataTable:
    Tasks tasks = new Tasks(tasks);
    // if desired we can add a new Task (=Row) to the table:
    Task taskToAdd = new Task {...};
    tasks.Add(taskToAdd);
    // convert to Destinations:
    Destinations destinations = tasks.ToDestinations();   // yes, only one line!
    // do you need the DataTable?
    DataTable destinationsTable = destinations.DataTable; // yes, also only one line!
