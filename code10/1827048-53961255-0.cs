    const string Xaml = "<ContextMenu xmlns =\"http://schemas.microsoft.com/winfx/2006/xaml/presentation\" xmlns:x=\"http://schemas.microsoft.com/winfx/2006/xaml\" " +
              "Background=\"White\" Width=\"175\" Height=\"100\"> " +
              "    <ContextMenu.Template> " +
              "        <ControlTemplate> " +
              "            <Grid x:Name=\"ContextMenuGrid\" Background=\"{TemplateBinding Background}\"> " +
              "                  <Grid x:Name=\"BeverageGrid\" Background=\"{TemplateBinding Background}\" Height=\"50\"> " +
              "                      <Grid.ColumnDefinitions> " +
              "                          <ColumnDefinition Width=\"0.5*\" /> " +
              "                          <ColumnDefinition Width=\"3.5*\" /> " +
              "                          <ColumnDefinition Width=\"6*\" /> " +
              "                      </Grid.ColumnDefinitions> " +
              "                      <Image Grid.Column=\"1\" Grid.RowSpan=\"3\" Source=\"/DinerPOS;component/Resources/Images/Restaurant/Beverages/Beverage.png\" Stretch=\"Fill\" /> " +
              "                      <TextBlock Grid.Column=\"2\" Grid.RowSpan=\"3\" Text=\"Beverages\" HorizontalAlignment=\"Center\" TextAlignment=\"Center\" VerticalAlignment=\"Center\" /> " +
              "                 </Grid> " +
              "            </Grid> " +
              "        </ControlTemplate> " +
              "    </ContextMenu.Template> " +
              "</ContextMenu>";
    ContextMenu ct = XamlReader.Parse(Xaml) as ContextMenu;
