            async void OnItemSelected(object sender, SelectedItemChangedEventArgs e)
        {
            Publication p = (Publication)e.SelectedItem;
            Debug.WriteLine(p);
            if (p.folderID.Equals("-1"))
            {
                using (Stream respStream = await post(p.docNum))
                {
                    byte[] buffer = new byte[respStream.Length];
                    respStream.Read(buffer, 0, buffer.Length);
                    string path = System.Environment.GetFolderPath(Environment.SpecialFolder.MyDocuments);
                    File.WriteAllBytes(path + "foo.pdf", buffer);
                    await Navigation.PushAsync(new PDFViewPage(path + "foo.pdf"));
                    //Device.OpenUri(new Uri(path + "foo.pdf"));
                }
            }
            else
            {
                await Navigation.PushAsync(new PublicationsPage(p.folderID));
            }
        }
