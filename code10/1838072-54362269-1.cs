        <ListBox ItemsSource="{Binding your view}">
             <ListBox.Resources>
                 <local:ToAssemblageConverter x:Key="toAssemblageConverter"/>
             </ListBox.Resources>
             <ListBox.GroupStyle>
                <GroupStyle HidesIfEmpty="True">
                    <GroupStyle.HeaderTemplate>
                        <DataTemplate>
                            <StackPanel Orientation="Horizontal"
                                        DataContext="{Binding Items, Converter={StaticResource ResourceKey=toAssemblageConverter}}">
                                <TextBlock Margin="5 0" Text="{Binding Quantite}"/>
                                <TextBlock Margin="5 0" Text="{Binding Id}"/>
                                ...
                            </StackPanel     
                        </DataTemplate>
                    </GroupStyle.HeaderTemplate>
                </GroupStyle>
            </ListBox.GroupStyle>           
        </ListBox>
 
    public class ToAssemblageConverter : IValueConverter
    {
        public object Convert (object value, Type targetType, object parameter, System.Globalization.CultureInfo culture)
        {
            var cl = (IEnumerable)value;
            return new Assemblage {
                Quantite = cl.Sum(c => c.Quantite),
                ID = 0,
                IdAffaire = cl.First().IdAffaire,
                Name = cl.First().Name,
                Priorite = 0,
                Dessin = cl.First().Dessin,
                Groupe = cl.First().Groupe,
                Priorite = cl.Max(c=>c.Priorite),
                ListeIdOperations = cl.First().ListeIdOperations,
            }
        }
    }
