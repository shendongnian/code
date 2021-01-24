     private void albums_SelectionChanged(object sender, SelectionChangedEventArgs e)
        {
                int index = albums.SelectedIndex;
                
            if (index >= 0)
                 {
                int indexid = albums.SelectedIndex;
                var selectedObject = albums.SelectedItems[0] as Albumclass.Albumlist2;
                if (selectedObject == null)
                {
                    return;
                }
                id = selectedObject.Id;
                //obteniendo lista de albums
                string tagurl = "http://" + serverurl + "/server/xml.server.php?action=album_songs&auth=" + token + "&filter=" + id;
                string[] tagarray = { tagurl, "song", "track", "title", "composer", "artist", "time", "tag", "comment", "url" };//Creando array con datos a utilizar
                //Lennado ListView Songs
                Songs.ItemsSource = null;
                songs = new ObservableCollection<Albumclass.Albumlist2>();
                songs = xmlobserv.Xmlparser(tagarray);
                Songs.ItemsSource = songs;
                 }
        }
