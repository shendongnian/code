    using System;
    using System.Collections.Generic;
    using System.IO;
    using System.Linq;
    using System.Runtime.InteropServices.WindowsRuntime;
    using Windows.Foundation;
    using Windows.Foundation.Collections;
    using Windows.Media.Core;
    using Windows.Storage;
    using Windows.Storage.Pickers;
    using Windows.UI.Xaml;
    using Windows.UI.Xaml.Controls;
    using Windows.UI.Xaml.Controls.Primitives;
    using Windows.UI.Xaml.Data;
    using Windows.UI.Xaml.Input;
    using Windows.UI.Xaml.Media;
    using Windows.UI.Xaml.Navigation;
    namespace VideoSamplePlayer
    {
        public sealed partial class VideoPlayer : Page
        {           
            public VideoPlayer()
            {
                this.InitializeComponent();
            }
            // The event handler, which will listen for MainPage's VideoSelected
            //     event, after being subscribed to it on the MainPage.
            public void VideoSelected(object sender, VideoSelectionArgs e)
            {
                // Get the MediaSource from the event arguments, and set up and start
                //    the media player.
                mediaPlayerElement.MediaPlayer.Source = e.Source;
                mediaPlayerElement.MediaPlayer.RealTimePlayback = true;
                mediaPlayerElement.MediaPlayer.Play();
            }
        }
    }
