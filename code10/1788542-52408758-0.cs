    public partial class Form1 : Form
    {
      public Form1() 
      {
        InitializeComponent();
      }
      private void Form1_Load(object sender, EventArgs e)
      {
        //
        var incident = new Incident(0, "default", "default", "default", "default");
        var list = new List<Incident>();
        list.Add(incident);
        // Convert object to Json
        var strResultJson = JsonConvert.SerializeObject(list);
        // Write values as Json file
        File.WriteAllText(@"configuration.json", strResultJson);
        // Read values from file
        var strReadJson = File.ReadAllText(@"configuration.json");  
        // Convert to Json Object
        var x = JsonConvert.DeserializeObject<List<Incident>>(strReadJson);
        foreach (var option in x.Select(p => p.Name))
        {
            comboBox1.Items.Add(option);
        }
      }
    }
    public class Incident
    {
      public Incident()
      {
      }
      public Incident(int id, string name, string option, string description, string otherDescription)
      {
        Id = id;
        Name = name;
        Option = option;
        Description = description;
        OtherDescription = otherDescription;
      }
      public int Id { get; set; }
      public string Name { get; set; }
      public string Option { get; set; }
      public string Description { get; set; }
      public string OtherDescription { get; set; }
    }
   
