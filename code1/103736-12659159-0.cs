    //(1) Declare a property with 'get','set' in code behind
    public partial class my_class:Window {
      public String My_Property { get; set; }
      ...
    //(2) Initialise the property in constructor of code behind
    public partial class my_class:Window {
      ...
      public my_class() {
         My_Property = "my-string-value";
         InitializeComponent();
      }
    
    //(3) Set data context in window xaml and specify a binding
    <Window ...
    DataContext="{Binding RelativeSource={RelativeSource Self}}">
      <TextBlock Text="{Binding My_Property}"/>
    </Window>
    
