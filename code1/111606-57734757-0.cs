    const string WINDOW_STATE_FILE = "windowstate.json";
    public static void SaveWindowState(Form form)
    {
        var state = new WindowStateInfo
        {
            WindowLocation = form.Location,
            WindowState = form.WindowState
        };
        File.WriteAllText(WINDOW_STATE_FILE, JsonConvert.SerializeObject(state));
    }
    public static void LoadWindowState(Form form)
    {
        if (!File.Exists(WINDOW_STATE_FILE)) return;
        var state = JsonConvert.DeserializeObject<WindowStateInfo>(File.ReadAllText(WINDOW_STATE_FILE));
        if (state.WindowState.HasValue) form.WindowState = state.WindowState.Value;
        if (state.WindowLocation.HasValue) form.Location = state.WindowLocation.Value;
    }
    public class WindowStateInfo
    {
        public FormWindowState? WindowState { get; set; }
        public Point? WindowLocation { get; set; }
    }
