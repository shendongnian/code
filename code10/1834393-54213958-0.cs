    void onOpen()
    {
        var selected = comobFileTypes.SelectedItem;
    
        if ( selected != null ) {
            var files = Directory.EnumerateFiles(sourceDIR.Text, "*.*", SearchOption.AllDirectories).Where(
                    s => s.EndsWith( selected.ToString());
        }
    
        return;
    }
