    void onOpen()
    {
        var selected = comobFileTypes.SelectedItem;
    
        if ( selected != null ) {
            string ext = "." + selected.ToString();
            var files = Directory.EnumerateFiles(sourceDIR.Text, "*.*", SearchOption.AllDirectories).Where(
                    s => s.EndsWith( ext );
            // ...more things...
        }
    
        return;
    }
