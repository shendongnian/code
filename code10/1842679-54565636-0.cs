    protected String WidgetOutput;
    protected String DatabaseEntry;
    protected String WidgetName;
    protected String WidgetDescription;
    protected void Page_Load(object sender, EventArgs e) {
        // Set some sample variable content
        WidgetName = "Fred The Widget";
        WidgetDescription = "I am a basic widget";
        // Load value of DatabaseEntry from database. (Setting it manually here for testing purposes.)
        DatabaseEntry = "<div><h1>Widget Info</h1><p>This widget's name is <strong>%%WidgetName%%</strong>.</p><p>This widget's description is <strong>%%WidgetDescription%%<strong>.</p></div>";
        // Prepare the database entry for output by replacing placeholders with actual variable contents.
        DatabaseEntry = DatabaseEntry.Replace("%%WidgetName%%", WidgetName);
        DatabaseEntry = DatabaseEntry.Replace("%%WidgetDescription%%", WidgetDescription);
        // Populate the variable that will be output on the page
        WidgetOutput = DatabaseEntry;
    }
