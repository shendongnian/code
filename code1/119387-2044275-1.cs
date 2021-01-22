    progressBarzipping.Minimum = 0; 
    progressBarzipping.Maximum = listBoxfiles.Items.Count;
    using (Stream fs = new FileStream(PathToNewZip, FileMode.Create, FileAccess.Write))
    {
        using (ZipFile zip = new ZipFile()) 
        { 
           zip.AddFiles(listboxFiles.Items);
           // do the progress bar: 
           zip.SaveProgress += (sender, e) => {
              if (e.EventType == ZipProgressEventType.Saving_BeforeWriteEntry) {
                 progressBarzipping.PerformStep();
              }
           };
           zip.Save(fs); 
        }
    } 
