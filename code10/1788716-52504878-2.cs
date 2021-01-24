        <MediaPlayerElement x:Name="mediaPlayerElement" 
                                    Grid.ColumnSpan="2" 
                                    Grid.RowSpan="4" 
                                    AutoPlay="True"  
                                    AreTransportControlsEnabled="True"             
             <MediaPlayerElement.TransportControls >
                <local:CustomMediaTransportControls IsCompact="False"
                                           IsPlaybackRateButtonVisible="True"
                                           IsEnabled="True"
                                           Plus500="Plus500"   <!-- Use the name you added in the EventHandler you added for the cuscom command bar
                </local:CustomMediaTransportControls>
            </MediaPlayerElement.TransportControls>
