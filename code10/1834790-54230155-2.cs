        // ...
        if (GetItems.getItems.itemsModel[i] != null)
        {
            // optional here add a loading or default texture 
            // to be displayed until texture is downloaded e.g.
            newObj.transform.GetChild(2).GetComponent<RawImage>().texture = someDefaultTexture;                         
            // start the download
            StartCoroutine(DownloadImage(i, 
                // executed on success
                (s) => 
                {
                    OnSuccess(newObj.transform.GetChild(2).GetComponent<RawImage>(), s);
                },
                // optional for visualizing download errors
                (e) =>
                {
                    OnError(e);
                }
            ));
        }
        // ...
                     
