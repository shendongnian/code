    <!-- language: lang-js -->
    <var>Visual.WIN.ctrlListView.OnColumnClick</var>  : 
    // Déterminer si la colonne sélectionnée est déjà la colonne triée.
    var sorter = eventSender.ListViewItemSorter;
    if ( eventArgs.Column == sorter .SortColumn )
    {
        // Inverser le sens de tri en cours pour cette colonne.
        if (sorter.Order == SortOrder.Ascending)
        {
            sorter.Order = SortOrder.Descending;
        }
        else
        {
            sorter.Order = SortOrder.Ascending;
        }
    }
    else
    {
        // Définir le numéro de colonne à trier ; par défaut sur croissant.
        sorter.SortColumn = eventArgs.Column;
        sorter.Order = SortOrder.Ascending;
    }
    // Procéder au tri avec les nouvelles options.
    eventSender.Sort();
