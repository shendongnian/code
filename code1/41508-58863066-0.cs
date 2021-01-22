cs
private void Form1_Load(object sender, EventArgs e)
{
    var colors = new List<Code>()
    {
        new Code() {Value= "R", Text = "Red"},
        new Code() {Value= "G", Text = "Green"},
        new Code() {Value= "B", Text = "Blue"}
    };
    var users = new List<User>()
    {
        new User() {Name = "Briana", FavoriteColor = "B"},
        new User() {Name = "Grace", FavoriteColor = "G"}
    };
    var colorCol = new DataGridViewComboBoxColumn();
    colorCol.DataSource = colors;
    colorCol.DisplayMember = "Text";
    colorCol.ValueMember = "Value";
    colorCol.DataPropertyName = "FavoriteColor";
    dataGridView1.Columns.Add(colorCol);
    dataGridView1.DataSource = users;
}
Some classes:
cs
public class Code
{
    public string Value { get; set; }
    public string Text { get; set; }
}
public class User
{
    public string Name { get; set; }
    public string FavoriteColor { get; set; }
}
