     MediaControlplayer  vcMediaPlayerMaster = new MediaControlplayer();
     Binding myMuteBinding = new Binding("Mute");
     myMuteBinding.Source = vcMediaPlayerMaster;
     myMuteBinding.UpdateSourceTrigger = UpdateSourceTrigger.PropertyChanged;
     myMuteBinding.Mode = BindingMode.TwoWay;
     btnAudioToggle.SetBinding(SimpleButton.IsCheckedProperty, myMuteBinding);
