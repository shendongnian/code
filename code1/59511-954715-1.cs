    // infers the correct list type from the contents
    static IList AutoCast(this IList list) {
        if (list == null) throw new ArgumentNullException("list");
        if (list.Count == 0) throw new InvalidOperationException(
              "Cannot AutoCast an empty list");
        Type type = list[0].GetType();
        IList result = (IList) Activator.CreateInstance(typeof(List<>)
              .MakeGenericType(type), list.Count);
        foreach (object obj in list) result.Add(obj);
        return result;
    }
    // usage
    [STAThread]
    static void Main() {
        Application.EnableVisualStyles();
        List<IListItem> data = new List<IListItem> {
            new User { Id = "1", Name = "abc", UserSpecificField = "def"},
            new User { Id = "2", Name = "ghi", UserSpecificField = "jkl"},
        };
        ShowData(data, "Before change - no UserSpecifiedField");
        ShowData(data.AutoCast(), "After change - has UserSpecifiedField");
    }
    static void ShowData(object dataSource, string caption) {
        Application.Run(new Form {
            Text = caption,
            Controls = {
                new DataGridView {
                    Dock = DockStyle.Fill,
                    DataSource = dataSource,
                    AllowUserToAddRows = false,
                    AllowUserToDeleteRows = false
                }
            }
        });
    }
