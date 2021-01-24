    public partial class Form1 : Form
    {
        public Form1()
        {
            InitializeComponent();
        }
        // This will hold the items displayed in the ListBox
        private BindingList<Task> taskList;
        // Manually creating the controls here so you can copy/paste
        private ListBox taskListBox;
        private Button btnEdit;
        private void Form1_Load(object sender, EventArgs e)
        {
            // Create a few "Tasks" and add them to our BindingList
            taskList = new BindingList<Task>
            {
                new Task("john", "jSpec", "jType", "jProg",
                    "jContact", "jStart", "jEnd"),
                new Task("mary", "mSpec", "mType", "mProg",
                    "mContact", "mStart", "mEnd"),
                new Task("luther", "lSpec", "lType", "lProg",
                    "lContact", "lStart", "lEnd"),
            };
            // Create the ListBox
            taskListBox = new ListBox
            {
                FormattingEnabled = true,
                Location = new Point(56, 60),
                Name = "listBox1",
                Size = new Size(281, 290),
                TabIndex = 0,
                Width = Width - 50,
                Left = 10,
                Top = 30,
                DataSource = taskList
            };
            Controls.Add(taskListBox);
            // Create the Button
            btnEdit = new Button
            {
                Text = "Edit Task",
                Width = 100,
                Left = taskListBox.Left + taskListBox.Width - 100,
                Top = taskListBox.Top + taskListBox.Height + 10
            };
            btnEdit.Click += BtnEdit_Click;
            Controls.Add(btnEdit);
        }
        // When you select an item in the list box and click the button,
        // the selected item will be automatically updated. You can modify
        // this code to get the actual values from the user for whatever 
        // properties you want the user to be able to update
        private void BtnEdit_Click(object sender, EventArgs e)
        {
            // Pretend we get a value from the user
            var newName = "New Name";
            var newEnd = "New End";
            // Get the selected task
            var selectedTask = taskList[taskListBox.SelectedIndex];
            selectedTask.Name = newName;
            selectedTask.End = newEnd;
            // Update the data in the listbox and notify the user
            taskList.ResetBindings();
            MessageBox.Show("Updated selected item");
        }
    }
    // The Task class, with properties to represent the values from your code sample
    public class Task
    {
        public string Name { get; set; }
        public string Spec { get; set; }
        public string Type { get; set; }
        public string Progress { get; set; }
        public string Contact { get; set; }
        public string Start { get; set; }
        public string End { get; set; }
        public Task(string name, string spec, string type, string progress,
            string contact, string start, string end)
        {
            Name = name; Spec = spec; Type = type; Progress = progress;
            Contact = contact; Start = start; End = end;
        }
        public override string ToString()
        {
            return $"{Name,-10} {Spec,-35} {Type,-20} {Progress,-20} " +
                   $"{Contact,-20} {Start,-15} {End,-10}";
        }
    }
