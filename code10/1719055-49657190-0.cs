    //AUDIO DEFAULT
    AudioTableAdapter databaseDataSetAudioDefaultTableAdapter = new AudioTableAdapter();
    databaseDataSetAudioDefaultTableAdapter.Fill(databaseDataSet.Audio);
    defaultDataSet.AudioDataTable audio_table = new defaultDataSet.AudioDataTable();
    using (SQLiteConnection con = new SQLiteConnection("Data Source=" + configurations_folder + AppDbFile)) 
    {
        con.Open();
        SQLiteCommand cmd = con.CreateCommand();
        cmd.CommandText = string.Format("SELECT * FROM Audio WHERE Type = 0");
        using (SQLiteDataAdapter adapter = new SQLiteDataAdapter(cmd))
            adapter.Fill(audio_table);
    }
    System.Windows.Data.CollectionViewSource AudioDefaultViewSource = ((System.Windows.Data.CollectionViewSource)(this.FindResource("AudioDefaultViewSource")));
    AudioDefaultViewSource.Source = audio_table;
    AudioDefaultViewSource.View.MoveCurrentToFirst();
    //AUDIO CUSTOMIZED
    AudioTableAdapter databaseDataSetAudioCustomizedTableAdapter = new AudioTableAdapter();
    databaseDataSetAudioCustomizedTableAdapter.Fill(databaseDataSet.Audio);
    defaultDataSet.AudioDataTable audio_customized_table = new defaultDataSet.AudioDataTable();
    using (SQLiteConnection con = new SQLiteConnection("Data Source=" + configurations_folder + AppDbFile))
    {
        con.Open();
        SQLiteCommand cmd = con.CreateCommand();
        cmd.CommandText = string.Format("SELECT * FROM Audio WHERE Type = 1");
        using (SQLiteDataAdapter adapter = new SQLiteDataAdapter(cmd))
            adapter.Fill(audio_customized_table);
    }
    System.Windows.Data.CollectionViewSource AudioCustomizedViewSource = ((System.Windows.Data.CollectionViewSource)(this.FindResource("AudioCustomizedViewSource")));
    AudioCustomizedViewSource.Source = audio_customized_table;
    AudioCustomizedViewSource.View.MoveCurrentToFirst();
